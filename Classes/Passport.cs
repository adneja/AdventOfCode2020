using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aoc.Classes
{
    public class Passport
    {
        private int byr;
        private int iyr;
        private int eyr;

        private string hgt;
        private string hcl;
        private string ecl;

        private string pid;

        public Passport(int byr, int iyr, int eyr, string hgt, string hcl, string ecl, string pid)
        {
            this.byr = byr;
            this.iyr = iyr;
            this.eyr = eyr;
            this.hgt = hgt;
            this.hcl = hcl;
            this.ecl = ecl;
            this.pid = pid;
        }

        public bool Validate()
        {
            bool[] checks =
            {
                ValidNumber(byr, 1920, 2002),
                ValidNumber(iyr, 2010, 2020),
                ValidNumber(eyr, 2020, 2030),
                Regex.IsMatch(hgt, "^[1][5][0-9]cm$|^[1][6-8][0-9]cm$|^[1][9][0-3]cm$|^[5-6][0-9]in$|^[7][0-6]in$"),
                Regex.IsMatch(hcl, "^#([a-f]|[0-9]){6}"),
                Regex.IsMatch(ecl, "amb|blu|brn|gry|grn|hzl|oth"),
                Regex.IsMatch(pid, "\\b[0-9]{9}\\b")
            };

            return Array.TrueForAll(checks, c => c);
        }

        private bool ValidNumber(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}