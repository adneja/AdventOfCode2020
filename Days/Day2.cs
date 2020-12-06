using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day2 : Day, IDay
    {
        private readonly List<Password> passwords;

        public Day2(string path) : base(path)
        {
            this.passwords = new List<Password>();

            foreach(string line in puzzleInput)
            {
                string[] words = line.Split(' ');
                int numOne = int.Parse(words[0].Split('-')[0]);
                int numTwo = int.Parse(words[0].Split('-')[1]);
                char letter = char.Parse(words[1].Substring(0,1));
                string password = words[2];

                this.passwords.Add(new Password(numOne, numTwo, letter, password));
            }
        }

        public int PartOne()
        {
            return passwords.Count(password => password.CheckPolicyOne());
        }

        public int PartTwo()
        {
            return passwords.Count(password => password.CheckPolicyTwo());
        }

        public void Solve()
        {
            PrintAnswer(2, PartOne(), PartTwo());
        }
    }
}
