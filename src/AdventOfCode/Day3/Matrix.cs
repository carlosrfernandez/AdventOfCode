using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class Matrix
    {
        public const int Width = 1000;
        public const int Length = 1000;

        private readonly (int Id, List<int> value)[,] _map = new (int Id, List<int> value)[1000,1000];
        private readonly Dictionary<int, Claim> _claims;
        private readonly List<Claim> _claimCollection;
        public Matrix(IEnumerable<Claim> claims)
        {
            var collection = claims as Claim[] ?? claims.ToArray();
            _claimCollection = new List<Claim>(collection);
            _claims = collection.ToDictionary(x => x.Id);
        }

        public int GetOccupiedSize()
        {
            _claimCollection.ForEach(Add);
            return GetSomeArea((x, y) => _map[x, y].value != null && _map[x,y].value.Count > 1);
        }

        public int GetLoneWolf()
        {
            foreach (var claim in _claimCollection)
            {
                var isLonely = claim.GetOccupation().Select(valueTuple => _map[valueTuple.x, valueTuple.y])
                    .All(coordinate => coordinate.value.All(x => x == claim.Id));
                if (!isLonely) continue;
                return claim.Id;
            }

            return -1;
        }

        private void Add(Claim structure)
        {
            foreach (var valueTuple in structure.GetOccupation())
            {
                var list = _map[valueTuple.Item1, valueTuple.Item2].value;
                if (list == null)
                {
                    list = new List<int>(); // first guy in the block
                }
                else
                {
                    list.ForEach(c =>
                    {
                        var cs = _claims[c];
                        cs.AddNeighborId(structure.Id);
                        _claims[c] = cs;

                    });
                }

                if (!list.Contains(structure.Id))
                {
                    list.Add(structure.Id);
                }

                _map[valueTuple.Item1, valueTuple.Item2].value = list;
            }
        }

        private static int  GetSomeArea(Func<int, int, bool> predicate)
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