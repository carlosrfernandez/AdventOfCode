using System;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class Puzzle1 : PuzzleBase
    {
        public override string Day { get; } = "Day 1";
        public override int PuzzleNumber { get; } = 1;

        public Puzzle1(string inputFile) : base(inputFile)
        {
        }

        public override void Run()
        {
            var input = ReadFile();
            var frequencies = input.Select(int.Parse);
            var result = frequencies.Aggregate(0, (acc, next) => acc + next);
            Console.WriteLine($"{Day} Puzzle {PuzzleNumber} result is {result}");
        }
    }
}