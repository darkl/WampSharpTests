using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using Newtonsoft.Json.Linq;
using WampSharp.Binding;
using WampSharp.V2;
using WampSharp.V2.Core.Contracts;
using WampSharp.WebSocket4Net;

namespace WampSharpDemo
{
    internal class Client
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static int _idSrc;
        private readonly int _id = Interlocked.Add(ref _idSrc, 1);
        private readonly Func<bool> _shouldTerminate;

        public static volatile int EventsConsumed;

        public Client(Func<bool> shouldTerminate, int id = 0)
        {
            if (id > 0)
            {
                _id = id;
            }
            _shouldTerminate = shouldTerminate;
        }

        public void SubscribeAndWait(int workTimeMillis = 85)
        {
            var factory = new DefaultWampChannelFactory();
            var binding = new JTokenMsgpackBinding();

            var channel = factory.CreateChannel("realm", new WebSocket4NetBinaryConnection<JToken>(Configs.ServerAddress, binding), binding);
            try
            {
                channel.Open().Wait();
                //
                for (var i = 0; i < Configs.N_SUBJECTS; i++)
                {
                    string topicUri = Configs.SUBJECT_ + i;
                    channel.RealmProxy.Services.GetSubject<WsEvent>(topicUri).Subscribe(
                        @event =>
                        {
                            Interlocked.Add(ref EventsConsumed, 1);
                            //
                            if (@event.Id%100 == 0)
                            {
                                Logger.Info("Client #" + _id + ". Processing event #" + @event.Id);
                            }
                            //
                            Thread.Sleep(workTimeMillis);
                        },
                        ex =>
                        {
                            Logger.Error($"Error during {topicUri} subscription", ex);
                        });
                }
                //
                while (!_shouldTerminate())
                {
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error in Client #" + _id, ex);
                // ReSharper disable once LocalizableElement
                MessageBox.Show("Error in Client #" + _id + "\r\n\r\n" + ex, "Error");
                Application.Exit();
            }
            finally
            {
                channel.Close("Test complete", new GoodbyeDetails()
                {
                    Message = "Client #" + _id
                });
            }
        }

        /// <summary>
        ///     Run number of clients.
        ///     Each client is subscribed to all server subjects.
        /// </summary>
        /// <returns>Action to terminate running subscribers.</returns>
        public static Action<bool> RunLoadTest(int numClients = 10, bool local = true, int workTimeMillis = 85)
        {
            if (local)
            {
                var terminateLoadTest = false;
                for (var i = 0; i < numClients; i++)
                {
                    Task.Run(() => { new Client(() => terminateLoadTest).SubscribeAndWait(workTimeMillis); });
                }
                return (terminateRandom) => { terminateLoadTest = true; };
            }
            //
            var processes = new List<Process>();
            for (var i = 0; i < numClients; i++)
            {
                var p = new Process
                {
                    StartInfo =
                    {
                        FileName = Process.GetCurrentProcess().MainModule.FileName.Replace(".vshost", ""),
                        Arguments = "" + (i + 1) + " " + workTimeMillis
                    }
                };
                if (p.Start())
                {
                    processes.Add(p);
                }
            }
            return (terminateRandom) =>
            {
                if (terminateRandom)
                {
                    try
                    {
                        processes.Find(process => true).Kill();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    processes.ForEach(process =>
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    });
                }
            };
        }
    }
}