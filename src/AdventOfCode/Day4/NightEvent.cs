using System;

namespace AdventOfCode.Day4
{
    public class NightEvent
    {
        public NightEvent(DateTime eventTime, Actions action)
        {
            EventTime = eventTime;
            Action = action;
        }

        public DateTime EventTime { get; }
        public Actions Action { get; }
    }
}