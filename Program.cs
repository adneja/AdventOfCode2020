using Aoc.Days;

namespace Aoc
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Day1 dayOne = new Day1("input1.txt");
            dayOne.Solve();

            Day2 dayTwo = new Day2("input2.txt");
            dayTwo.Solve();

            Day3 dayThree = new Day3("input3.txt");
            dayThree.Solve();

            Day4 dayFour = new Day4("input4.txt");
            dayFour.Solve();

            Day5 dayFive = new Day5("input5.txt");
            dayFive.Solve();

            Day6 daySix = new Day6("input6.txt");
            daySix.Solve();

            Day7 daySeven = new Day7("input7.txt");
            daySeven.Solve();
        }
    }
}
