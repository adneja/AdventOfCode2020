using System;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day1 : Day, IDay
    {
        private readonly int[] numbers;

        public Day1(string path) : base(path)
        {
            this.numbers = Array.ConvertAll(puzzleInput, int.Parse);
        }

        public int PartOne()
        {
            for(int a = 0; a < numbers.Length; a++)
            {
                for(int b = a; b < numbers.Length; b++)
                {
                    int aValue = numbers[a],
                        bValue = numbers[b];

                    if(aValue + bValue == 2020)
                    {
                        return aValue * bValue;
                    }
                }
            }

            return 0;
        }

        public int PartTwo()
        {
            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a; b < numbers.Length; b++)
                {
                    for (int c = b; c < numbers.Length; c++)
                    {
                        int aValue = numbers[a],
                            bValue = numbers[b],
                            cValue = numbers[c];

                        if (aValue + bValue + cValue == 2020)
                        {
                            return aValue * bValue * cValue;
                        }
                    }
                }
            }

            return 0;
        }

        public void Solve()
        {
            PrintAnswer(1, PartOne(), PartTwo());
        }
    }
}
