using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day7 : Day, IDay
    {
        Graph<string, int> rules;

        public Day7(string path) : base(path)
        {
            Regex ruleReg = new Regex(@"(?<amount>\d\s)(?<color>\D*)( bag)");
            rules = new Graph<string, int>();
            
            foreach(string line in puzzleInput)
            {
                string color = line.Split(" bags contain ")[0].Trim();
                string[] colorRules = line.Split(" bags contain ")[1].Split(", ");

                foreach(string rule in colorRules)
                {
                    if(rule != "no other bags.")
                    {
                        Match ruleMatch = ruleReg.Match(rule);
                        int ruleAmount = int.Parse(ruleMatch.Groups["amount"].Value);
                        string ruleColor = ruleMatch.Groups["color"].Value;
                        rules.Add(color, ruleColor, ruleAmount);
                    }
                }
            }
        }

        public int PartOne()
        {
            string target = "shiny gold";
            int count = 0;

            foreach(var color in rules.Edges)
            {
                if(rules.IsReachable(color.Key, target)) count++;
            }

            return count;
        }

        public int PartTwo()
        {
            return -1;
        }

        public void Solve()
        {
            PrintAnswer(7, PartOne(), PartTwo());
        }
    }
}