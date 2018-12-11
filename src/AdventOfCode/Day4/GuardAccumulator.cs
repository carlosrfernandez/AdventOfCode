using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class GuardAccumulator
    {
        private readonly IDictionary<int, double> _ticksAsleep = new Dictionary<int, double>();

        private NightEvent LastEvent { get; set; }
        
        public GuardAccumulator()
        {
        }

        public void AddGuard(NightEvent e)
        {
            if (!_ticksAsleep.ContainsKey(e.GuardId))
            {
                _ticksAsleep.Add(e.GuardId, 0);
            }
            
            LastEvent = e;
        }

        public void AddAsleepEvent(NightEvent e)
        {
            if (LastEvent.GuardId != e.GuardId)
            {
                return;
            }

//            if (_minutesCount.ContainsKey(e.EventTime.Minute))
//            {
//                var count = _minutesCount[e.EventTime.Minute];
//                count++;
//                _minutesCount[e.EventTime.Minute] = count;
//            }
//            else
//            {
//                _minutesCount.Add(e.EventTime.Minute, 1);
//            }

            LastEvent = e;
        }

        public void WakeUp(NightEvent e)
        {
            if (LastEvent.GuardId != e.GuardId && LastEvent.Action != Actions.FallAsleep)
            {
                throw new InvalidOperationException("Cannot compute time asleep for 'wake up' if last known action is not fall asleep");
            }

            var currentTally = _ticksAsleep[e.GuardId];
            
            if (LastEvent.EventTime.Day != e.EventTime.Day) throw new InvalidOperationException();

            currentTally += LastEvent.EventTime.SubtractMinutesFromOther(e.EventTime);
            _ticksAsleep[e.GuardId] = currentTally;
        }

        public int GetTheSleepyGuy => _ticksAsleep.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
    }

    public class MinuteAccumulator
    {
        private IDictionary<int, int> _minuteMap = new Dictionary<int, int>();
        public MinuteAccumulator()
        {
            var kvp = Enumerable.Range(0, 60).Select(x => new KeyValuePair<int, int>(x, 0));
            foreach (var keyValuePair in kvp) _minuteMap.Add(keyValuePair    );
        }
        
        private NightEvent LastEvent { get; set; }

        public void FallAsleep(NightEvent e)
        {
            LastEvent = e;
        }

        public void WakeUp(NightEvent e)
        {
            if (LastEvent.Action == Actions.FallAsleep)
            {
                var minutes = Enumerable.Range(LastEvent.EventTime.Minute, e.EventTime.Minute - 1);
                foreach (var minute in minutes)
                {
                    if (_minuteMap.ContainsKey(minute))
                    {
                        var minuteMapValue = _minuteMap[minute];
                        minuteMapValue++;
                        _minuteMap[minute] = minuteMapValue;
                    }
                }
            }

            LastEvent = e;
        }

        public int GetMostUsedMinute => _minuteMap.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
    }
}