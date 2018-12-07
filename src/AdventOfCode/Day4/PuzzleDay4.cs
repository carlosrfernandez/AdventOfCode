using System;
using System.Collections.Generic;
using System.Linq;

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

            var repo = new ScheduleRepository(timeSeries);
            var guardScheduleAccumulatorDictionary = new Dictionary<int, GuardAccumulator>();
            //var streamSubscription = repo.GetScheduleStream().Scan()

            //var subscription = streamSubscription;           
        }
    }

    public class GuardAccumulator
    {
        //private readonly IDictionary<>
    }
}