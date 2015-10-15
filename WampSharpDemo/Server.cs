using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using log4net;
using WampSharp.Binding;
using WampSharp.Fleck;
using WampSharp.V2;
using WampSharp.V2.PubSub;
using WampSharp.V2.Realm;
using WampSharp.Vtortola;

namespace WampSharpDemo
{
    public class Server
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static Server _instance;
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private static IWampHostedRealm _realm;

        private readonly ConcurrentDictionary<string, TopicView> _topics =
            new ConcurrentDictionary<string, TopicView>();

        private readonly WampHost _wampHost;

        public static int Rate = 1000;
        public static int CurrentSessions;
        public int CurrentTopics {get { return _topics.Count; }}
        public static int CurrentSubscribers;

        private Server()
        {
            _wampHost = new WampHost();

            _wampHost.RegisterTransport(new FleckWebSocketTransport(Configs.ServerAddress),
                new JTokenMsgpackBinding());
            //_wampHost.RegisterTransport(new VtortolaWebSocketTransport(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2015), true),
            //    new JTokenMsgpackBinding());
            //
            _wampHost.Open();
            //
            _realm = _wampHost.RealmContainer.GetRealmByName("realm");
            _realm.SessionCreated +=
                (sender, args) =>
                {
                    Interlocked.Increment(ref CurrentSessions);
                    Logger.Info(sender + " session created: " + args.SessionId + " details=" + args.HelloDetails);
                };
            _realm.SessionClosed +=
                (sender, args) =>
                {
                    Interlocked.Decrement(ref CurrentSessions);
                    Logger.Info(sender + " session closed : " + args.SessionId + " reason=" + args.Reason +
                                " closeType=" + args.CloseType);
                };
            _realm.TopicContainer.TopicCreated +=
                (sender, args) =>
                {
                    _topics.TryAdd(args.Topic.TopicUri, new TopicView(args.Topic));
                    Logger.Info(sender + " topic created: " + args.Topic.TopicUri);
                };
            _realm.TopicContainer.TopicRemoved +=
                (sender, args) =>
                {
                    TopicView t;
                    _topics.TryRemove(args.Topic.TopicUri, out t);
                    Logger.Info(sender + " topic removed: " + t);
                };
            _realm.TopicContainer.Topics.ForEach(t => _topics.TryAdd(t.TopicUri, new TopicView(t)));
            //
            Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1 /*intervalSeconds*/)).Subscribe(l =>
            {
                var ticks = Rate; // produce 1000 events each second
                for (var t = 0; t <= ticks/10; ++t)
                    Parallel.For(t*10, (t + 1)*10, i =>
                    {
                        var random = new Random((int) (DateTime.Now.Ticks + i));
                        var topicUri = string.Intern(Configs.SUBJECT_ + random.Next(0, Configs.N_SUBJECTS));
                        TopicView topicView;
                        if (_topics.TryGetValue(topicUri, out topicView))
                        {
                            var wsEvent = new WsEvent(Math.Round(random.NextDouble()*100000)/100000.0);
                            topicView.Publish(wsEvent);
                            NumPublished = wsEvent.Id;
                            if (wsEvent.Id%10000 == 0)
                            {
                                Logger.Info("Published " + wsEvent.Id + " events");
                            }
                        }
                    });
            });
        }

        public long NumPublished { get; set; }

        /// <summary>
        ///     An instance of NJ4X Server (Singleton design pattern)
        /// </summary>
        public static Server Instance
        {
            get { return _instance ?? (_instance = new Server()); }
        }

        public void Dispose()
        {
            if (_wampHost != null)
            {
                _wampHost.Dispose();
            }
        }

        private class TopicView
        {
            private static readonly TaskFactory TaskFactory = new TaskFactory(new DedicatedThreadAffinedTaskScheduler(Environment.ProcessorCount));
            private readonly LinkedList<Task> _tasks = new LinkedList<Task>();
            // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
            private readonly IWampTopic _topic;
            private readonly string _topicUri;
            private long _cnt, _start, _last, _missStart, _missPeriodTotal, _cntTotal, _periodTotal;
            private volatile object _subject;
            private int _subscriptions, _missed, _missedTotal;

            public TopicView(IWampTopic topic)
            {
                _subject = null;
                Tps = int.MaxValue;
                _subscriptions = 0;
                _cnt = _cntTotal = _periodTotal = 0;
                _missed = 0;
                _topic = topic;
                _topicUri = _topic.TopicUri;
                _topic.TopicEmpty += (sender, args) =>
                {
                    if (Logger.IsInfoEnabled)
                    {
                        Logger.Info("Topic is empty: " + ToString());
                    }
                };
                _topic.SubscriptionAdded += (sender, args) =>
                {
                    Interlocked.Add(ref CurrentSubscribers, 1);
                    _subscriptions++;
                    if (Logger.IsInfoEnabled && _topicUri.EndsWith(".1"))
                    {
                        Logger.Info("Topic " + _topicUri + " added subscription: " + args.Subscriber.SessionId +
                                    " _subscriptions=" + _subscriptions);
                    }
                };
                _topic.SubscriptionRemoving += (sender, args) =>
                {
                    Interlocked.Add(ref CurrentSubscribers, -1);
                    _subscriptions--;
                    if (Logger.IsInfoEnabled && _topicUri.EndsWith(".1"))
                    {
                        Logger.Info("Topic " + _topicUri + " removed subscription: " + args.Session + " _subscriptions=" +
                                    _subscriptions);
                    }
                };
            }

            internal int Tps { set; private get; }

            public override string ToString()
            {
                return _topicUri + " processed " + _cntTotal + " events in " + (_periodTotal + (_last - _start)) +
                       " millis, "
                       + " skipped " + _missedTotal + " events in " + _missPeriodTotal + " millis";
            }

            public void Publish<T>(T evt)
            {
                if (_subscriptions == 0)
                {
                    return;
                }
                _cntTotal++;
                _last = Configs.CurrentTimeMillis();
                if (_cnt == 0 || (_last - _start) > 60000)
                {
                    _periodTotal += (_start > 0 ? _last - _start : 0);
                    _start = _last;
                    _cnt = 0;
                }
                //
                if (_cntTotal%1000 == 0 && Logger.IsInfoEnabled)
                {
                    var s = ToString();
                    ThreadPool.QueueUserWorkItem(state => { Logger.Info("Topic " + s); });
                }
                //
                var run = Tps == int.MaxValue;
                if (Tps < int.MaxValue)
                {
                    var tps = _last <= _start ? 1 : ((double) _cnt)/(_last - _start)*1000.0;
                    run = (tps < Tps /* * _subscriptions*/|| _missed > 0 && (_last - _missStart) > 10000);
                }
                if (run)
                {
                    if (_missed > 0)
                    {
                        _missedTotal += _missed;
                        _missPeriodTotal += (_last - _missStart);
                        _missed = 0;
                    }
                    _cnt += _subscriptions;
                    if (_subject == null)
                    {
                        _subject = _realm.Services.GetSubject<T>(_topicUri);
                    }
                    var t = TaskFactory.StartNew(() =>
                    {
                        if (_subscriptions > 0)
                        {
                            ((ISubject<T>) _subject).OnNext(evt);
                        }
                    });
/*
                    lock (_tasks)
                    {
                        _tasks.Where(task => task.IsCompleted || task.IsFaulted || task.IsCanceled)
                            .ToArray()
                            .ForEach(task => _tasks.Remove(task));
                        _tasks.AddLast(t);
                    }
*/
                }
                else
                {
                    if (_missed == 0)
                    {
                        _missStart = _last;
                    }
                    _missed++;
                }
            }
        }
    }

    /// <summary>
    ///     An implementation of <see cref="T:System.Threading.Tasks.TaskScheduler" /> which creates an underlying thread pool
    ///     and set processor affinity to each thread.
    ///     Each thread has own Task queue.
    /// </summary>
    public sealed class DedicatedThreadAffinedTaskScheduler : TaskScheduler, IDisposable
    {
        private List<BlockingCollection<Task>> _tasks;
        private List<Thread> _threads;

        /// <summary>
        ///     Create a new <see cref="T:RoundRobinThreadAffinedTaskScheduler" /> with a provided number of background threads.
        ///     Threads are pined to a logical core using a round robin algorithm.
        /// </summary>
        /// <param name="numberOfThreads">Total number of threads in the pool.</param>
        public DedicatedThreadAffinedTaskScheduler(int numberOfThreads)
        {
            if (numberOfThreads < 1)
                throw new ArgumentOutOfRangeException("numberOfThreads");
            var processorIndexes = Enumerable.Range(0, Environment.ProcessorCount).ToArray();
            CreateThreads(numberOfThreads, processorIndexes);
        }

        /// <summary>
        ///     Create a new <see cref="T:RoundRobinThreadAffinedTaskScheduler" /> with a provided number of background threads.
        ///     Threads are pined to a logical core using a round roubin algorithm choosen between provided processor indexes
        /// </summary>
        /// <param name="numberOfThreads">Total number of threads in the pool.</param>
        /// <param name="processorIndexes">
        ///     One or more logical processor identifier(s) the threads are allowed to run on. 0-based
        ///     indexes.
        /// </param>
        public DedicatedThreadAffinedTaskScheduler(int numberOfThreads, params int[] processorIndexes)
        {
            if (numberOfThreads < 1)
                throw new ArgumentOutOfRangeException("numberOfThreads");
            foreach (var num in processorIndexes)
            {
                if (num >= Environment.ProcessorCount || num < 0)
                    throw new ArgumentOutOfRangeException("processorIndexes",
                        string.Format(
                            "processor index {0} was supperior to the total number of processors in the system", num));
            }
            CreateThreads(numberOfThreads, processorIndexes);
        }

        /// <summary>
        ///     Indicates the maximum concurrency level this <see cref="T:System.Threading.Tasks.TaskScheduler" /> is able to
        ///     support.
        /// </summary>
        /// <returns>
        ///     Returns an integer that represents the maximum concurrency level.
        /// </returns>
        public override int MaximumConcurrencyLevel
        {
            get { return _threads.Count; }
        }

        private static ProcessThread CurrentProcessThread
        {
            get
            {
                var currentThreadId = GetCurrentThreadId();
                foreach (ProcessThread processThread in Process.GetCurrentProcess().Threads)
                {
                    if (processThread.Id == currentThreadId)
                        return processThread;
                }
                throw new InvalidOperationException(
                    string.Format("Could not retrieve native thread with ID: {0}, current managed thread ID was {1}",
                        currentThreadId, Thread.CurrentThread.ManagedThreadId));
            }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (_tasks == null)
                return;
            _tasks.ForEach(tasks => tasks.CompleteAdding());
            _threads.ForEach(t => t.Join());
            _tasks.ForEach(tasks => tasks.Dispose());
            _tasks = null;
        }

//        int maxStackSize = 10 * 1024 * 1024;
        int maxStackSize = 0;

        private void CreateThreads(int numberOfThreads, int[] processorIndexes)
        {
            _tasks = Enumerable.Range(0, numberOfThreads).Select(i => new BlockingCollection<Task>()).ToList();
            _threads =
                Enumerable.Range(0, numberOfThreads)
                    .Select(i =>
                    {
                        return new Thread(() => ThreadStartWithAffinity(i, processorIndexes), maxStackSize)
                                     {
                                         IsBackground = true,
                                         Name = "WampThread #" + (i + 1)
                                     };
                    }).ToList();
            _threads.ForEach(t => t.Start());
        }

        private void ThreadStartWithAffinity(int threadIndex, int[] processorIndexes)
        {
            SetThreadAffinity(processorIndexes[threadIndex%processorIndexes.Length]);
            try
            {
                foreach (var task in _tasks[threadIndex].GetConsumingEnumerable())
                    TryExecuteTask(task);
            }
            finally
            {
                RemoveThreadAffinity();
            }
        }

        /// <summary>
        ///     Queues a <see cref="T:System.Threading.Tasks.Task" /> to the scheduler.
        /// </summary>
        /// <param name="task">The <see cref="T:System.Threading.Tasks.Task" /> to be queued.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="task" /> argument is null.</exception>
        protected override void QueueTask(Task task)
        {
            _tasks.Aggregate((currMin, x) => currMin == null || currMin.Count > x.Count ? x : currMin).Add(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks.SelectMany(tasks => tasks).ToArray();
        }

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        private static void SetThreadAffinity(int processorIndex)
        {
            Thread.BeginThreadAffinity();
            CurrentProcessThread.ProcessorAffinity = new IntPtr(1 << processorIndex);
        }

        private static void RemoveThreadAffinity()
        {
            CurrentProcessThread.ProcessorAffinity = new IntPtr((1 << Environment.ProcessorCount) - 1);
            Thread.EndThreadAffinity();
        }
    }
}