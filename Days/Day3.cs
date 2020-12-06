using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day3 : Day, IDay
    {
        private readonly Terrain terrain;

        public Day3(string path) : base(path)
        {
            this.terrain = new Terrain(new List<string>(puzzleInput));
        }

        public int PartOne()
        {
            return terrain.Traverse(3, 1);
        }

        public int PartTwo()
        {
            int[] treeCounts =
            {
                terrain.Traverse(1, 1),
                terrain.Traverse(3, 1),
                terrain.Traverse(5, 1),
                terrain.Traverse(7, 1),
                terrain.Traverse(1, 2)
            };

            return treeCounts.Aggregate((acc, curr) => acc * curr);
        }

        public void Solve()
        {
            PrintAnswer(3, PartOne(), PartTwo());
        }
    }
}
