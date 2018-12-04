using System;
using System.Collections.Generic;
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
            var claimsStructure = input.Select(ClaimsStructure.ParseExact).ToList();

            if (input.Count == claimsStructure.Count)
            {
                var maxWidth = claimsStructure.Max(x => x.Width);
                var maxHeight = claimsStructure.Max(x => x.Height);
                var matrix = new Matrix();
                claimsStructure.ForEach(x => matrix.Add(x));
                var result = matrix.GetOccupiedSize();
                Console.WriteLine($"{Day} puzzle {PuzzleNumber} result: {result}");
                //var part2 = matrix.GetIdOfLoneWolf();
                //Console.WriteLine($"{Day} puzzle 2 result: {part2}");
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class Matrix
    {
        public const int Width = 1000;
        public const int Length = 1000;

        private readonly (int Id, int value)[,] _map = new (int Id, int value)[1000,1000];

        public Matrix()
        {
            
        }

        public void Add(ClaimsStructure structure)
        {
            foreach (var valueTuple in structure.GetOccupation())
            {
                _map[valueTuple.Item1, valueTuple.Item2].Id = valueTuple.id;
                _map[valueTuple.Item1, valueTuple.Item2].value++;
            }
        }

        public int GetOccupiedSize()
        {
            return GetSomeArea((x, y) => _map[x, y].value > 1);
        }

        private int  GetSomeArea(Func<int, int, bool> predicate)
        {
            var total = 0;
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    if (predicate(i, j)) total++;
                }
            }

            return total;
        }

    }
}