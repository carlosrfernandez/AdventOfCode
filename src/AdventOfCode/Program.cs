using System;
using System.IO;
using AdventOfCode.Day1;

namespace AdventOfCode
{
    class Program
    {
        private static readonly string BaseFolder = AppDomain.CurrentDomain.BaseDirectory;
        static void Main()
        {
            Console.WriteLine("Hello AdventOfCode 2018!");
            var day1Input = Path.Combine(BaseFolder, "input.txt");


            var p1 = new Puzzle1(day1Input);
            p1.Run();

            var p2 = new Puzzle2(day1Input);
            p2.Run();

            var day2Input = Path.Combine(BaseFolder, "inputD2.txt");
            var dp1 = new Day2.Puzzle1(day2Input);
            dp1.Run();

            var dp2 = new Day2.Puzzle2(day2Input);
            dp2.Run();

            var d3P1 = new Day3.Day3Puzzles("inputD3.txt");
            d3P1.Run();

            Console.ReadKey();
        }
    }
}
