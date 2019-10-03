using System;

namespace Auth.Util
{
    public static class Time
    {
        // all times will be stored and dealt with using Unix Epoch Time as milliseconds;
        //     manipulated in longs, and stored in strings using iso 8601 format
        // while it would be nice to manipulate dates using the built in DateTime class, and just hope everything runs
        //     smoothly. Real world databases do not allow for this fantasy scenario, it is very easy for dates to
        //     become misinterpreted during translation across varying applications and formats, is very consistent
        //     across languages that use long. Unfortunately, javascript does not have longs. Otherwise we would be
        //     storing dates as longs as well

        public static long CurrentTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static long DaysToMilliseconds(int days)
        {
            return DateTimeOffset.UnixEpoch.AddDays(days).ToUnixTimeMilliseconds();
        }

        public static long HoursToMilliseconds(int hours)
        {
            return DateTimeOffset.UnixEpoch.AddDays(hours).ToUnixTimeMilliseconds();
        }

        public static long MinutesToMilliseconds(int minutes)
        {
            return DateTimeOffset.UnixEpoch.AddDays(minutes).ToUnixTimeMilliseconds();
        }

        public static long SecondsToMilliSeconds(int seconds)
        {
            return DateTimeOffset.UnixEpoch.AddDays(seconds).ToUnixTimeMilliseconds();
        }
    }
}