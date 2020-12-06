using System;
using System.IO;

namespace Aoc.Classes
{
    interface IDay
    {
        int PartOne();
        int PartTwo();
        void Solve();
    }

    public class Day
    {
        public string[] puzzleInput;

        public Day(string path)
        {
            puzzleInput = File.ReadAllLines($"Resources/{path}");
        }

        public void PrintAnswer(int day, int partOne, int partTwo)
        {
            Console.WriteLine($"{day}.1: {partOne}");
            Console.WriteLine($"{day}.2: {partTwo}");
        }
    }
}
