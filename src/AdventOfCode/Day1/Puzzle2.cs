using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day1
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
            var input = ReadFile().Select(int.Parse).ToArray();
            var infiniteLoop = RecurseForever(input);
            var hash = new HashSet<int>();
            var firstDupe = infiniteLoop.First(x => !hash.Add(x));
            Console.WriteLine($"{Day} Puzzle {PuzzleNumber} result = {firstDupe}");
        }

        public IEnumerable<int> RecurseForever(params int[] collection)
        {
            var length = collection.Length;
            var count = 0;
            yield return 0; // start at 0
            var res = 0;
            while (true)
            {
                if (count == length)
                    count = 0;

                res += collection[count];
                yield return res;
                count++;
            }
        }
    }
}