using System;
using System.Linq;

namespace Aoc.Classes
{
    public class Password
    {
        private readonly int numOne;
        private readonly int numTwo;
        private readonly char letter;
        private readonly string password;

        public Password(int numOne, int numTwo, char letter, string password)
        {
            this.numOne = numOne;
            this.numTwo = numTwo;
            this.letter = letter;
            this.password = password;
        }

        public bool CheckPolicyOne()
        {
            int count = password.Count(c => c == letter);
            return count >= numOne && count <= numTwo;
        }

        public bool CheckPolicyTwo()
        {
            bool firstMatch = char.Parse(password.Substring(numOne - 1, 1)) == letter;
            bool secondMatch = char.Parse(password.Substring(numTwo - 1, 1)) == letter;

            return firstMatch != secondMatch;
        }
    }
}