using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Classes
{
    public class Terrain
    {
        private List<String> terrain;

        public Terrain(List<String> terrain)
        {
            this.terrain = terrain;
        }

        public int Traverse(int right, int down)
        {
            int xPos = 0,
                treeCount = 0;

            for(int i = down; i < terrain.Count(); i += down)
            {
                xPos = (xPos + right) % terrain[0].Length;
                if (terrain[i][xPos] == '#') treeCount++;
            }

            return treeCount;
        }
    }
}
