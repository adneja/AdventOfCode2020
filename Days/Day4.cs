using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day4 : Day, IDay
    {
        private readonly List<Passport> passports;
        private readonly string[] mandatoryFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public Day4(string path) : base(path)
        {
            this.passports = this.ParsePuzzleInput();
        }

        public List<Passport> ParsePuzzleInput()
        {
            List<Passport> passports = new List<Passport>();
            List<Dictionary<string, string>> passportData = new List<Dictionary<string, string>>();
            Dictionary<string, string> currPassport = new Dictionary<string, string>();

            foreach (string line in puzzleInput)
            {
                if (line.Length == 0)
                {
                    passportData.Add(currPassport);
                    currPassport = new Dictionary<string, string>();
                }
                else
                {
                    foreach (string word in line.Split(' '))
                    {
                        currPassport.Add(word.Split(':')[0], word.Split(':')[1]);
                    }
                }
            }

            passportData.Add(currPassport);

            foreach (Dictionary<string, string> dict in passportData)
            {
                int mandCount = mandatoryFields.Count(field => dict.ContainsKey(field));

                if(mandCount == mandatoryFields.Length)
                {
                    passports.Add(new Passport(int.Parse(dict["byr"]), int.Parse(dict["iyr"]), int.Parse(dict["eyr"]), dict["hgt"], dict["hcl"], dict["ecl"], dict["pid"]));
                }
            }

            return passports;
        }

        public int PartOne()
        {
            return passports.Count();
        }

        public int PartTwo()
        {
            return passports.Count(passport => passport.Validate());
        }

        public void Solve()
        {
            PrintAnswer(4, PartOne(), PartTwo());
        }
    }
}
