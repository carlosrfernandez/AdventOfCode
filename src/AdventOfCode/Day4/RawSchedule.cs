using System;

namespace AdventOfCode.Day4
{
    public class RawSchedule
    {
        public RawSchedule(DateTime time, string metadata)
        {
            Time = time;
            Metadata = metadata;
        }

        public DateTime Time { get; }
        public string Metadata { get; }
    }
}