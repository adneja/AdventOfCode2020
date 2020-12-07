using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Classes
{
    public class Decleration
    {
        private List<string> answers;

        public Decleration(string answer)
        {
            answers = new List<string>{answer};
        }
        
        public void AddAnswer(string answer)
        {
            answers.Add(answer);
        }

        public int GetDistinctAnswers()
        {
            return answers.Aggregate((acc, curr) => acc += curr).Distinct().Count();
        }

        public int GetCommonAnswers()
        {
            char[] distinct = answers.Aggregate((acc, curr) => acc += curr).Distinct().ToArray();
            int count = 0;

            foreach(char c in distinct)
            {
                if(answers.TrueForAll(a => a.Contains(c))) count++;
            }

            return count;
        }
    }
}