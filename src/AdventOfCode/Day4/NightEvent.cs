using System;

namespace AdventOfCode.Day4
{
    public class NightEvent
    {
        public NightEvent(int guardId, DateTime eventTime, Actions action)
        {
            GuardId = guardId;
            EventTime = eventTime;
            Action = action;
        }

        public int GuardId { get; }
        public DateTime EventTime { get; }
        public Actions Action { get; }
    }
}