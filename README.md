# WampSharpTests

Case 1:
    An unhandled exception of type 'WampSharp.V2.Core.Contracts.WampConnectionBrokenException' occurred in mscorlib.dll
    Additional information: Connetion got broken. CloseType:Goodbye, Reason: wamp.close.normal

    Current Thread: System.Reactive.PlatformServices.dll!System.Reactive.PlatformServices.ExceptionServicesImpl.Rethrow	Normal
 	 	 	 	 	 	mscorlib.dll!System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()	 
 	 	 	 	 	 	System.Reactive.PlatformServices.dll!System.Reactive.PlatformServices.ExceptionServicesImpl.Rethrow(System.Exception exception)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.ExceptionHelpers.Throw(System.Exception exception)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Stubs..cctor.AnonymousMethod__1(System.Exception ex)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.AnonymousSafeObserver<WampSharpDemo.WsEvent>.OnError(System.Exception error)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Select<WampSharp.V2.IWampSerializedEvent,WampSharpDemo.WsEvent>._.OnError(System.Exception error)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Where<WampSharp.V2.IWampSerializedEvent>._.OnError(System.Exception error)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.SafeObserver<WampSharp.V2.IWampSerializedEvent>.OnError(System.Exception error)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Merge<WampSharp.V2.IWampSerializedEvent>._.Iter.OnError(System.Exception error)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.SelectMany<System.Reactive.EventPattern<WampSharp.V2.Realm.WampSessionCloseEventArgs>,WampSharp.V2.IWampSerializedEvent>._.Iter.OnError(System.Exception error)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Throw<WampSharp.V2.IWampSerializedEvent>._.Invoke()	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.Scheduler.Invoke(System.Reactive.Concurrency.IScheduler scheduler, System.Action action)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.ImmediateScheduler.Schedule<System.Action>(System.Action state, System.Func<System.Reactive.Concurrency.IScheduler,System.Action,System.IDisposable> action)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.Scheduler.Schedule(System.Reactive.Concurrency.IScheduler scheduler, System.Action action)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Throw<WampSharp.V2.IWampSerializedEvent>._.Run()	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Throw<WampSharp.V2.IWampSerializedEvent>.Run(System.IObserver<WampSharp.V2.IWampSerializedEvent> observer, System.IDisposable cancel, System.Action<System.IDisposable> setSink)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.Run(System.Reactive.Concurrency.IScheduler _, System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State x)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.ScheduledItem<System.TimeSpan,System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State>.InvokeCore()	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.ScheduledItem<System.TimeSpan>.Invoke()	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.CurrentThreadScheduler.Trampoline.Run(System.Reactive.Concurrency.SchedulerQueue<System.TimeSpan> queue)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.CurrentThreadScheduler.Schedule<System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State>(System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State state, System.TimeSpan dueTime, System.Func<System.Reactive.Concurrency.IScheduler,System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State,System.IDisposable> action)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Concurrency.LocalScheduler.Schedule<System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State>(System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State state, System.Func<System.Reactive.Concurrency.IScheduler,System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.State,System.IDisposable> action)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Producer<WampSharp.V2.IWampSerializedEvent>.SubscribeRaw(System.IObserver<WampSharp.V2.IWampSerializedEvent> observer, bool enableSafeguard)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.ObservableExtensions.SubscribeSafe<WampSharp.V2.IWampSerializedEvent>(System.IObservable<WampSharp.V2.IWampSerializedEvent> source, System.IObserver<WampSharp.V2.IWampSerializedEvent> observer)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.SelectMany<System.Reactive.EventPattern<WampSharp.V2.Realm.WampSessionCloseEventArgs>,WampSharp.V2.IWampSerializedEvent>._.SubscribeInner(System.IObservable<WampSharp.V2.IWampSerializedEvent> inner)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.SelectMany<System.Reactive.EventPattern<WampSharp.V2.Realm.WampSessionCloseEventArgs>,WampSharp.V2.IWampSerializedEvent>._.OnNext(System.Reactive.EventPattern<WampSharp.V2.Realm.WampSessionCloseEventArgs> value)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Subjects.Subject<System.Reactive.EventPattern<WampSharp.V2.Realm.WampSessionCloseEventArgs>>.OnNext(System.Reactive.EventPattern<WampSharp.V2.Realm.WampSessionCloseEventArgs> value)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.FromEventPattern.Impl<System.EventHandler<WampSharp.V2.Realm.WampSessionCloseEventArgs>,WampSharp.V2.Realm.WampSessionCloseEventArgs>.GetHandler.AnonymousMethod__1(object sender, WampSharp.V2.Realm.WampSessionCloseEventArgs eventArgs)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.V2.Client.WampSessionClient<Newtonsoft.Json.Linq.JToken>.OnConnectionBroken(WampSharp.V2.Realm.WampSessionCloseEventArgs e)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.V2.Client.WampSessionClient<Newtonsoft.Json.Linq.JToken>.RaiseConnectionBroken<Newtonsoft.Json.Linq.JToken>(WampSharp.Core.Serialization.IWampFormatter<Newtonsoft.Json.Linq.JToken> formatter, WampSharp.V2.Realm.SessionCloseType sessionCloseType, Newtonsoft.Json.Linq.JToken details, string reason)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.V2.Client.WampSessionClient<Newtonsoft.Json.Linq.JToken>.Goodbye(Newtonsoft.Json.Linq.JToken details, string reason)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.V2.Client.WampClient<Newtonsoft.Json.Linq.JToken>.Goodbye(Newtonsoft.Json.Linq.JToken details, string reason)	 
 	 	 	 	 	 	[Lightweight Function]	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.Core.Dispatch.Handler.WampMethodBuilder<Newtonsoft.Json.Linq.JToken,object>.BuildMethod.AnonymousMethod__0(object client, WampSharp.Core.Message.WampMessage<Newtonsoft.Json.Linq.JToken> message)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.Core.Dispatch.WampIncomingMessageHandler<Newtonsoft.Json.Linq.JToken,object>.HandleMessage(object client, WampSharp.Core.Message.WampMessage<Newtonsoft.Json.Linq.JToken> message)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.Core.Dispatch.WampIncomingMessageHandler<Newtonsoft.Json.Linq.JToken,object>.HandleMessage(WampSharp.Core.Message.WampMessage<Newtonsoft.Json.Linq.JToken> message)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.Core.Client.WampServerProxyHandler<Newtonsoft.Json.Linq.JToken>.OnMessageArrived(WampSharp.Core.Message.WampMessage<Newtonsoft.Json.Linq.JToken> wampMessage)	 
 	 	 	 	 	 	WampSharp.dll!WampSharp.Core.Client.WampServerProxyHandler<Newtonsoft.Json.Linq.JToken>.MessageArrived(object sender, WampSharp.Core.Listener.WampMessageArrivedEventArgs<Newtonsoft.Json.Linq.JToken> e)	 
 	 	 	 	 	 	WampSharp.WebSocket4Net.dll!WampSharp.WebSocket4Net.WebSocket4NetConnection<Newtonsoft.Json.Linq.JToken>.RaiseMessageArrived(WampSharp.Core.Message.WampMessage<Newtonsoft.Json.Linq.JToken> message)	 
 	 	 	 	 	 	WampSharp.WebSocket4Net.dll!WampSharp.WebSocket4Net.WebSocket4NetBinaryConnection<Newtonsoft.Json.Linq.JToken>.OnDataReceived(object sender, WebSocket4Net.DataReceivedEventArgs e)	 
 	 	 	 	 	 	WebSocket4Net.dll!WebSocket4Net.WebSocket.FireDataReceived(byte[] data)	 
 	 	 	 	 	 	WebSocket4Net.dll!WebSocket4Net.Command.Binary.ExecuteCommand(WebSocket4Net.WebSocket session, WebSocket4Net.WebSocketCommandInfo commandInfo)	 
 	 	 	 	 	 	WebSocket4Net.dll!WebSocket4Net.WebSocket.ExecuteCommand(WebSocket4Net.WebSocketCommandInfo commandInfo)	 
 	 	 	 	 	 	WebSocket4Net.dll!WebSocket4Net.WebSocket.OnDataReceived(byte[] data, int offset, int length)	 
 	 	 	 	 	 	WebSocket4Net.dll!WebSocket4Net.WebSocket.client_DataReceived(object sender, SuperSocket.ClientEngine.DataEventArgs e)	 
 	 	 	 	 	 	WebSocket4Net.dll!SuperSocket.ClientEngine.ClientSession.OnDataReceived(byte[] data, int offset, int length)	 
 	 	 	 	 	 	WebSocket4Net.dll!SuperSocket.ClientEngine.AsyncTcpSession.ProcessReceive(System.Net.Sockets.SocketAsyncEventArgs e)	 
 	 	 	 	 	 	WebSocket4Net.dll!SuperSocket.ClientEngine.AsyncTcpSession.SocketEventArgsCompleted(object sender, System.Net.Sockets.SocketAsyncEventArgs e)	 
 	 	 	 	 	 	System.dll!System.Net.Sockets.SocketAsyncEventArgs.OnCompleted(System.Net.Sockets.SocketAsyncEventArgs e)	 
 	 	 	 	 	 	System.dll!System.Net.Sockets.SocketAsyncEventArgs.ExecutionCallback(object ignored)	 
 	 	 	 	 	 	mscorlib.dll!System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state, bool preserveSyncCtx)	 
 	 	 	 	 	 	mscorlib.dll!System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state, bool preserveSyncCtx)	 
 	 	 	 	 	 	mscorlib.dll!System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext executionContext, System.Threading.ContextCallback callback, object state)	 
 	 	 	 	 	 	System.dll!System.Net.Sockets.SocketAsyncEventArgs.FinishOperationSuccess(System.Net.Sockets.SocketError socketError, int bytesTransferred, System.Net.Sockets.SocketFlags flags)	 
 	 	 	 	 	 	System.dll!System.Net.Sockets.SocketAsyncEventArgs.CompletionPortCallback(uint errorCode, uint numBytes, System.Threading.NativeOverlapped* nativeOverlapped)	 
 	 	 	 	 	 	mscorlib.dll!System.Threading._IOCompletionCallback.PerformIOCompletionCallback(uint errorCode, uint numBytes, System.Threading.NativeOverlapped* pOVERLAP)	 
    
Case 2:
Case 3:
    No _realm.TopicContainer.TopicRemoved event fired
    ** FIXED in 1.2.2.53-dev **
    
Case 4:
    System.StackOverflowException was unhandled
    Message: An unhandled exception of type 'System.StackOverflowException' occurred in mscorlib.dll
      System.Reactive.Core.dll!System.Reactive.Producer<System.Reactive.Unit>.SubscribeRaw	Normal
 	 	 	 	 	 	mscorlib.dll!System.MulticastDelegate.CtorRTClosed(object target, System.IntPtr methodPtr)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Producer<System.Reactive.Unit>.SubscribeRaw(System.IObserver<System.Reactive.Unit> observer, bool enableSafeguard)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.ObservableExtensions.SubscribeSafe<System.Reactive.Unit>(System.IObservable<System.Reactive.Unit> source, System.IObserver<System.Reactive.Unit> observer)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Defer<System.Reactive.Unit>._.Run()	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Defer<System.Reactive.Unit>.Run(System.IObserver<System.Reactive.Unit> observer, System.IDisposable cancel, System.Action<System.IDisposable> setSink)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Producer<System.Reactive.Unit>.SubscribeRaw(System.IObserver<System.Reactive.Unit> observer, bool enableSafeguard)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.ObservableExtensions.SubscribeSafe<System.Reactive.Unit>(System.IObservable<System.Reactive.Unit> source, System.IObserver<System.Reactive.Unit> observer)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Merge<System.Reactive.Unit>.MergeConcurrent.Subscribe(System.IObservable<System.Reactive.Unit> innerSource)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Merge<System.Reactive.Unit>.MergeConcurrent.Iter.OnCompleted()	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Defer<System.Reactive.Unit>._.OnCompleted()	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.AsObservable<System.Reactive.Unit>._.OnCompleted()	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Subjects.AsyncSubject<System.Reactive.Unit>.Subscribe(System.IObserver<System.Reactive.Unit> observer)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.ObservableExtensions.SubscribeSafe<System.Reactive.Unit>(System.IObservable<System.Reactive.Unit> source, System.IObserver<System.Reactive.Unit> observer)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.AsObservable<System.Reactive.Unit>.Run(System.IObserver<System.Reactive.Unit> observer, System.IDisposable cancel, System.Action<System.IDisposable> setSink)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.Reactive.Producer<System.Reactive.Unit>.SubscribeRaw(System.IObserver<System.Reactive.Unit> observer, bool enableSafeguard)	 
 	 	 	 	 	 	System.Reactive.Core.dll!System.ObservableExtensions.SubscribeSafe<System.Reactive.Unit>(System.IObservable<System.Reactive.Unit> source, System.IObserver<System.Reactive.Unit> observer)	 
 	 	 	 	 	 	System.Reactive.Linq.dll!System.Reactive.Linq.ObservableImpl.Defer<System.Reactive.Unit>._.Run()	 
 	 	 	 	 	 	...
 	 	 	 	 	 	The maximum number of stack frames supported by Visual Studio has been exceeded.	 

Case 5:
    No _topic.SubscriptionRemoving/Removed event fired
    
Case 6:
    Check multiple exceptions in WampSharpDemo.log:
    ---
    [WampSharp.Fleck.FleckWebSocketTransport] Failed to send. Disconnecting.
System.AggregateException: One or more errors occurred. ---> System.IO.IOException: Unable to write data to the transport connection: An existing connection was forcibly closed by the remote host. ---> System.Net.Sockets.SocketException: An existing connection was forcibly closed by the remote host
   at System.Net.Sockets.Socket.EndSend(IAsyncResult asyncResult)
   at System.Net.Sockets.NetworkStream.EndWrite(IAsyncResult asyncResult)
   --- End of inner exception stack trace ---
   at System.Net.Sockets.NetworkStream.EndWrite(IAsyncResult asyncResult)
   at System.Threading.Tasks.TaskFactory`1.FromAsyncCoreLogic(IAsyncResult iar, Func`2 endFunction, Action`1 endAction, Task`1 promise, Boolean requiresSynchronization)
   
   As a result: An unhandled exception of type 'System.StackOverflowException' occurred in mscorlib.dll



