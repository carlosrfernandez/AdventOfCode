using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class Guard
    {
        private readonly List<NightEvent> _schedule;
        public Guard(int id, IEnumerable<NightEvent> schedule)
        {
            _schedule = schedule as List<NightEvent>;
            Id = id;
        }

        public int Id { get; }
        public IReadOnlyList<NightEvent> Schedule => _schedule;

        public static Guard NewGuardBeginsShift(int id, DateTime startOfShift)
        {
            return new Guard(id, new List<NightEvent> { new NightEvent(id, startOfShift, Actions.BeginShift)});
        }

        public Guard BeginShift(DateTime dateTime)
        {
            var action = new NightEvent(Id, dateTime, Actions.BeginShift);
            _schedule.Add(action);
            return new Guard(Id, _schedule);
        }

        public Guard FallAsleep(DateTime dateTime)
        {
            var action = new NightEvent(Id, dateTime, Actions.FallAsleep);
            _schedule.Add(action);
            return new Guard(Id, _schedule);
        }

        public Guard WakeUp(DateTime wakeUpTime)
        {
            _schedule.Add(new NightEvent(Id, wakeUpTime, Actions.WakeUp));
            return new Guard(Id, _schedule);
        }

        /*public int GetBestSleepTime()
        {
            var timeAsleep = _schedule.Where(x => x.Action.Equals(Actions.FallAsleep)).ToList();
            var g = _schedule.Where(x => x.Action == Actions.FallAsleep).GroupBy(x => x.EventTime.Hour);
            return 1;
        }*/
    }
}