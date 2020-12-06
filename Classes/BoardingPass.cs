using System;
using System.Linq;

namespace Aoc.Classes
{
    public class BoardingPass
    {
        private int row;
        private int col;
        private int id;

        public BoardingPass(string bsp)
        {
            int[] rows = Enumerable.Range(0, 128).ToArray();
            int[] cols = Enumerable.Range(0, 8).ToArray();

            for (int i = 0; i < bsp.Length; i++)
            {
                switch (bsp[i])
                {
                    case 'F':
                        rows = rows.Skip(0).Take(rows.Length / 2).ToArray();
                        break;
                    case 'B':
                        rows = rows.Skip(rows.Length / 2).Take(rows.Length / 2).ToArray();
                        break;
                    case 'L':
                        cols = cols.Skip(0).Take(cols.Length / 2).ToArray();
                        break;
                    case 'R':
                        cols = cols.Skip(cols.Length / 2).Take(cols.Length / 2).ToArray();
                        break;
                }
            }

            Row = rows[0];
            Col = cols[0];
            Id = (Row * 8) + Col;
        }

        public BoardingPass(int row, int col)
        {
            Row = row;
            Col = col;
            id = (Row * 8) + Col;
        }

        public int Id { get => id; set => id = value; }
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
    }
}
