using System.Threading;

namespace WampSharpDemo
{
    public class WsEvent
    {
        private static long _idSrc;

        public WsEvent()
        {
        }

        public WsEvent(double v)
        {
            Id = Interlocked.Add(ref _idSrc, 1);
            V = v;
        }

        public long Id { get; set; }
        public double V { get; set; }
    }
}