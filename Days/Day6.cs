using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day6 : Day, IDay
    {
        private readonly Dictionary<int,Decleration> declerations;
        
        public Day6(string path) : base(path)
        {
            declerations = new Dictionary<int,Decleration>();
            int groupId = 0;

            foreach(string line in puzzleInput)
            {
                if(line.Length == 0) groupId++;
                else
                {
                    if(!declerations.ContainsKey(groupId))declerations.Add(groupId, new Decleration(line));
                    else declerations[groupId].AddAnswer(line);
                }
            }
        }

        public int PartOne()
        {
            return declerations.Values.Aggregate(0, (acc, curr) => acc += curr.GetDistinctAnswers());
        }

        public int PartTwo()
        {
            return declerations.Values.Aggregate(0, (acc, curr) => acc += curr.GetCommonAnswers());
        }

        public void Solve()
        {
            PrintAnswer(6, PartOne(), PartTwo());
        }
    }
}