using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AdventOfCode.Day4
{
    public class PuzzleDay4 : PuzzleBase
    {
        public PuzzleDay4(string inputFile) : base(inputFile)
        {
        }

        public override string Day { get; } = "Day 4";
        public override int PuzzleNumber { get; } = 1;
        public override void Run()
        {
            var input = ReadFile();
            var timeSeries = input.Select(x =>
            {
                var timestamp = x.Substring(1, 16);
                var theRest = x.Substring(19, x.Length - 19);

                var theTime = DateTime.Parse(timestamp);
                return new RawSchedule(theTime, theRest);
            });

            GetPart1(timeSeries);
        }

        private static void GetPart1(IEnumerable<RawSchedule> timeSeries)
        {
            var rawSchedules = timeSeries.ToList();
            var repo = new ScheduleRepository(rawSchedules);

            var task = GetSleepyFella(repo);
            task.Wait();
            var sleepyGuy = task.Result;

            Console.WriteLine($"Sleepy Guy: {sleepyGuy}");

//            var resultTask = rawSchedules.Where(x => x);
//            resultTask.Wait();
//          3  var result = resultTask.Result;
//            Console.WriteLine($"{sleepyGuy} * {result} is {sleepyGuy * result}");
        } 


        private static async Task<int> GetSleepyFella(ScheduleRepository repo)
        {
            var sleepyFella = await repo.GetScheduleStream()
                .Aggregate(
                    new GuardAccumulator(),
                    (acc, next) =>
                    {
                        switch (next.Action)
                        {
                            case Actions.BeginShift:
                                acc.AddGuard(next);
                                break;
                            case Actions.FallAsleep:
                                acc.AddAsleepEvent(next);
                                break;
                            case Actions.WakeUp:
                                acc.WakeUp(next);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        return acc;
                    })
                .Select(x => x.GetTheSleepyGuy);

            var listOfGuardEvents = new List<NightEvent>();
            var guyStream = repo.GetScheduleStream().Subscribe(x => listOfGuardEvents.Add(x));

            var nightEvents = listOfGuardEvents
                .Where(x => x.GuardId == sleepyFella)
                .ToList();    
            var result = nightEvents
                .Aggregate(new MinuteAccumulator(), (accumulator, @event) =>
                {
                    if (@event.Action == Actions.WakeUp) accumulator.WakeUp(@event);
                    if (@event.Action == Actions.FallAsleep) accumulator.FallAsleep(@event);

                    return accumulator;
                }).GetMostUsedMinute;
            
            return sleepyFella * result;
        }
    }
}