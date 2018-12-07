using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            var listOfGuards = GetGuards(timeSeries);

            
        }

        private static Dictionary<int, Guard> GetGuards(IEnumerable<RawSchedule> timeSeries)
        {
            var listOfGuards = new Dictionary<int, Guard>();
            var sortedTime = timeSeries.OrderBy(x => x.Time).ToList();
            var regex = new Regex("\\d");
            var lastId = -1;
            sortedTime.ForEach(x =>
            {
                if (x.Metadata.Contains("Guard"))
                {
                    var match = regex.Match(x.Metadata);
                    if (match.Success)
                    {
                        var id = int.Parse(match.Value);
                        lastId = id;
                        if (listOfGuards.ContainsKey(id))
                        {
                            var guard = listOfGuards[id].BeginShift(x.Time);
                            listOfGuards[id] = guard;
                        }
                        else
                        {
                            listOfGuards.Add(id, Guard.NewGuardBeginsShift(id, x.Time));
                        }
                    }
                }

                if (x.Metadata.Contains("wake"))
                {
                    var guard = listOfGuards[lastId].WakeUp(x.Time);
                    listOfGuards[lastId] = guard;
                }

                if (x.Metadata.Contains("falls"))
                {
                    var guard = listOfGuards[lastId].FallAsleep(x.Time);
                    listOfGuards[lastId] = guard;
                }
            });
            return listOfGuards;
        }
    }

    public class RawSchedule
    {
        public RawSchedule(DateTime time, string Metadata)
        {
            Time = time;
            this.Metadata = Metadata;
        }

        public DateTime Time { get; }
        public string Metadata { get; }
    }
}