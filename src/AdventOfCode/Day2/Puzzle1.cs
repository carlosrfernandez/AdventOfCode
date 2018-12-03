using System;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class Puzzle1 : PuzzleBase
    {
        public Puzzle1(string inputFile) : base(inputFile)
        {
        }

        public override string Day { get; } = "Day 2";
        public override int PuzzleNumber { get; } = 1;
        public override void Run()
        {
            var input = ReadFile();

            var g1 = input
                .Select(x =>
                {
                    var innerG1 = x
                        .GroupBy(c => c)
                        .FirstOrDefault(c => c.Count() == 2)?.Count();

                    var innerG2 = x
                        .GroupBy(c => c)
                        .FirstOrDefault(c => c.Count() == 3)?.Count();
                    
                    return (innerG1 ?? 0, innerG2 ?? 0);
                }).ToList();

            var g2 = g1.Count(x => x.Item1 > 0);
            var g3 = g1.Count(x => x.Item2 > 0);

            Console.WriteLine($"{Day} Puzzle {PuzzleNumber} result: {g2 * g3}");

        }
    }
}