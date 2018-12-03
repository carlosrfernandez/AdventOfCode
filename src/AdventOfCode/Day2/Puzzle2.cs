using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class Puzzle2 : PuzzleBase
    {
        public Puzzle2(string inputFile) : base(inputFile)
        {
        }

        public override string Day { get; } = "Day 2";
        public override int PuzzleNumber { get; } = 2;

        public override void Run()
        {
            var rf = ReadFile();
            /*var rf = new[]
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };*/
            var input = GetChars(rf);
            // implement
        }

        private static int Diff(IEnumerable<char> part1, IEnumerable<char> part2)
        {
           
            var count = part1.Except(part2).Count();
            return count;
        }

        private static List<char[]> GetChars(IEnumerable<string> s)
        {
            return s.Select(x =>  x.ToCharArray()).ToList();
        }
    }
}