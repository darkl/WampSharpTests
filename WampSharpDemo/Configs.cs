using System;

namespace WampSharpDemo
{
    public class Configs
    {
        /// <summary>
        ///     Server binding address.
        /// </summary>
        public static readonly string ServerAddress = "ws://127.0.0.1:2015/wamp/sharp";

        // ReSharper disable once InconsistentNaming
        public const string SUBJECT_ = "com.sharp.wamp.";
        // ReSharper disable once InconsistentNaming
        public const int N_SUBJECTS = 1000;

        public static long CurrentTimeMillis()
        {
            return DateTime.UtcNow.ToFileTime()/10000L - 11644473600000L;
        }

        public static DateTime ToDateTime(long millis)
        {
            return DateTime.FromFileTime((millis + 11644473600000L)*10000L);
        }
    }
}