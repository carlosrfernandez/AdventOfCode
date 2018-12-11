using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day4
{
    public class ScheduleRepository
    {
        // storing this here for now... might need it later.
        private readonly List<RawSchedule> _rawSchedule;

        public ScheduleRepository(IEnumerable<RawSchedule> rawSchedule)
        {
            _rawSchedule = rawSchedule.OrderBy(x => x.Time).ToList();
        }
        
        public IObservable<NightEvent> GetScheduleStream()
        {
            var regex = new Regex("\\d");
            var lastId = -1;
            return Observable.Create<NightEvent>(obs =>
            {
                _rawSchedule.ForEach(x =>
                {
                    if (x.Metadata.Contains("Guard"))
                    {
                        var match = regex.Match(x.Metadata);
                        if (match.Success)
                        {
                            var id = int.Parse(match.Value);
                            lastId = id;
                            obs.OnNext(new NightEvent(lastId, x.Time, Actions.BeginShift));
                        }
                    }

                    if (x.Metadata.Contains("wake"))
                    {
                        var nightEvent = new NightEvent(lastId, x.Time, Actions.WakeUp);
                        obs.OnNext(nightEvent);
                    }

                    if (x.Metadata.Contains("falls"))
                    {
                        obs.OnNext(new NightEvent(lastId, x.Time, Actions.FallAsleep));
                    }
                });

                obs.OnCompleted();

                return Disposable.Empty;
            });
        }

        public IObservable<NightEvent> GetGuardStream(int guardId)
        {
            return GetScheduleStream().Where(x => x.GuardId == guardId);
        }
    }
}