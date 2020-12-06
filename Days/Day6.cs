using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day6 : Day, IDay
    {
        private readonly Dictionary<int,string> declarations;
        
        public Day6(string path) : base(path)
        {
            declarations = new Dictionary<int,string>();
            int groupId = 0;

            foreach(string line in puzzleInput)
            {
                if(line.Length == 0) groupId++;
                
                if(!declarations.ContainsKey(groupId))
                {
                    declarations.Add(groupId, line);
                }
                else
                {
                    foreach(char c in line)
                    {
                        if(!declarations[groupId].Contains(c)) declarations[groupId] += c;
                    }
                }
            }
        }

        public int PartOne()
        {
            return declarations.Values.Aggregate((acc, curr) => acc += curr).Length;
        }

        public int PartTwo()
        {
            return -1;
        }

        public void Solve()
        {
            PrintAnswer(6, PartOne(), PartTwo());
        }
    }
}