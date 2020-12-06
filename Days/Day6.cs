using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day6 : Day, IDay
    {
        private readonly Dictionary<int,Decleration> declarations;
        
        public Day6(string path) : base(path)
        {
            declarations = new Dictionary<int,Decleration>();
            int groupId = 0;

            foreach(string line in puzzleInput)
            {
                if(line.Length == 0) groupId++;
                else
                {
                    if(!declarations.ContainsKey(groupId))declarations.Add(groupId, new Decleration(line));
                    else declarations[groupId].AddAnswer(line);
                }
            }
        }

        public int PartOne()
        {
            return declarations.Values.Aggregate(0, (acc, curr) => acc += curr.GetDistinctAnswers());
        }

        public int PartTwo()
        {
            return declarations.Values.Aggregate(0, (acc, curr) => acc += curr.GetCommonAnswers());
        }

        public void Solve()
        {
            PrintAnswer(6, PartOne(), PartTwo());
        }
    }
}