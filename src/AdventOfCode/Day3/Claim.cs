using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class Claim
    {
        public int Id { get; }
        public int InchesFromLeft { get; }
        public int InchesFromTop { get; }
        public int Width { get; }
        public int Height { get; }

        public List<int> Neighbors { get; }

        private Claim(int id, int inchesFromLeft, int inchesFromTop, int width, int height)
        {
            Id = id;
            InchesFromLeft = inchesFromLeft;
            InchesFromTop = inchesFromTop;
            Height = height;
            Width = width;
            Neighbors = new List<int>();
        }

        public static Claim ParseExact(string token)
        {
            // could do regex here
            var strings = token.Split(' ');
            var id = int.Parse(string.Join("", strings[0].Skip(1)));
            var inches = strings[2].Replace(":", "").Split(',');
            var inchesFromLeft = int.Parse(inches[0]);
            var inchesFromTop = int.Parse(inches[1]); // this will fail

            var dimensions = strings[3].Split('x');
            var width = int.Parse(dimensions[0]);
            var height = int.Parse(dimensions[1]);

            return new Claim(id, inchesFromLeft, inchesFromTop, width, height);
        }

        public void AddNeighborId(int id)
        {
            if (Neighbors.Contains(id)) return;
            Neighbors.Add(id);
        }

        public IEnumerable<(int x, int y , int id)> GetOccupation()
        {
            for (var i = InchesFromLeft; i < InchesFromLeft + Width; i++)
            {
                for (var j = InchesFromTop; j < InchesFromTop + Height; j++)
                {
                    yield return (j, i, Id);
                }
            }
        }

        public override string ToString()
        {
            return $"{Id}|{InchesFromLeft}|{InchesFromTop}|{Width}|{Width}";
        }
    }
}