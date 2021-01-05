using System;

namespace ChessNET
{
    public static class TimeSpanExtensions
    {
        public static string ToShortString(this TimeSpan timeSpan)
        {
            return timeSpan
                .ToString(@"d\d\ hh\hmm\mss\s")
                .TrimStart(' ', 'd', 'h', 'm', 's', '0');
        }
    }
}