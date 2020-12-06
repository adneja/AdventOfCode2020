using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Classes;

namespace Aoc.Days
{
    public class Day5 : Day, IDay
    {
        private readonly List<BoardingPass> boardingPasses;
        private readonly int minId;
        private readonly int maxId;

        public Day5(string path) : base(path)
        {
            boardingPasses = new List<BoardingPass>();

            foreach(string bsp in puzzleInput)
            {
                boardingPasses.Add(new BoardingPass(bsp));
            }

            minId = GetMinId();
            maxId = GetMaxId();
        }

        private int GetMinId()
        {
            int min = 0;

            foreach (BoardingPass bp in boardingPasses)
            {
                if (bp.Id < min) min = bp.Id;
            }

            return min;
        }

        private int GetMaxId()
        {
            int max = 0;

            foreach (BoardingPass bp in boardingPasses)
            {
                if (bp.Id > max) max = bp.Id;
            }

            return max;
        }

        public int PartOne()
        {
            return maxId;
        }

        public int PartTwo()
        {
            Dictionary<int, BoardingPass> seats = new Dictionary<int, BoardingPass>();
            int mySeat = -1;
            
            this.boardingPasses.ForEach(bp => seats.Add(bp.Id, bp));

            for(int i = minId; i < maxId; i++)
            {
                bool free = !seats.ContainsKey(i);
                bool prevExists = seats.ContainsKey(i - 1);
                bool nextExists = seats.ContainsKey(i + 1);

                if (free && prevExists && nextExists) mySeat = i;     
            }

            return mySeat;
        }

        public void Solve()
        {
            PrintAnswer(5, PartOne(), PartTwo());
        }
    }
}