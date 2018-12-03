using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public abstract class PuzzleBase : IPuzzle
    {
        public string InputFile { get; }
        public abstract string Day { get; }
        public abstract int PuzzleNumber { get; }
        protected PuzzleBase(string inputFile)
        {
            InputFile = inputFile;
        }

        public abstract void Run();

        protected virtual IEnumerable<string> ReadFile()
        {
            return File.ReadAllLines(InputFile, Encoding.UTF8);
        }
    }
}