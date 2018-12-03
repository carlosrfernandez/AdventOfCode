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
            var input = GetChars(rf).ToList();
            var res = DiffSet(input[0], input.Skip(1).ToArray());

            
            // fonbwmjquwtapeyzikghtvdxl
            // Console.WriteLine($"{Day} puzzle {PuzzleNumber} result {string.Join("", result)}");
            // implement
        }

        private static (char[], char[]) DiffSet(char[] head, char[][] tail)
        {
            foreach (var ch in tail)
            {
                if (Diff(head, ch) != 1)
                {
                    continue;
                }

                return (head, ch);
            }

            return DiffSet(tail[0], tail.Skip(1).ToArray());
        }

        private static int Diff(char[] part1, char[] part2)
        {
            var difference = 0;
            for (var i = 0; i < part1.Length; i++)
            {
                if (part1[i] != part2[i])
                {
                    difference++;
                }

                if (difference > 1) return 2;
            }

            return difference;
        }

        private static List<char[]> GetChars(IEnumerable<string> s)
        {
            return s.Select(x =>  x.ToCharArray()).ToList();
        }
    }
}