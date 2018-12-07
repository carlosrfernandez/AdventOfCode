using System;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class Day3Puzzles : PuzzleBase
    {
        public Day3Puzzles(string inputFile) : base(inputFile)
        {
        }

        public override string Day { get; } = "Day 3";
        public override int PuzzleNumber { get; } = 1;

        public override void Run()
        {
            var input = ReadFile().ToList();
            var claimsStructure = input.Select(Claim.ParseExact).ToList();

            var matrix = new Matrix(claimsStructure);
            var result = matrix.GetOccupiedSize();
            Console.WriteLine($"{Day} puzzle {PuzzleNumber} result: {result}");
            var part2 = matrix.GetLoneWolf();
            Console.WriteLine($"{Day} puzzle 2 result: {part2}");
        }
    }
}