using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_22.Problems
{
    public class Problem04 : IProblem<int, int>
    {
        public int DoPartA()
        {
            var ranges = ReadRanges("04");
            var sum = 0;

            foreach (var range in ranges)
            {
                var firstContainsSecond = range.firstRange.Start.Value <= range.secondRange.Start.Value && range.firstRange.End.Value >= range.secondRange.End.Value;
                var secondContainsFirst = range.secondRange.Start.Value <= range.firstRange.Start.Value && range.secondRange.End.Value >= range.firstRange.End.Value;

                if (firstContainsSecond || secondContainsFirst)
                    sum++;
            }

            return sum;
        }

        public int DoPartB()
        {
            var ranges = ReadRanges("04");
            var sum = 0;

            foreach (var range in ranges)
            {
                var isRangesDifferent = range.firstRange.End.Value < range.secondRange.Start.Value || range.firstRange.Start.Value > range.secondRange.End.Value;
                
                if (!isRangesDifferent)
                    sum++;
            }

            return sum;
        }

        private IEnumerable<(Range firstRange, Range secondRange)> ReadRanges(string inputName)
        {
            return Utils.InputToStringArray(inputName)
                .Select(line => {
                    var ranges = line.Split(",");

                    var firstRange = ranges[0].Split("-").Select(x => Convert.ToInt32(x)).ToArray();
                    var secondRange = ranges[1].Split("-").Select(x => Convert.ToInt32(x)).ToArray();

                    return (firstRange[0]..firstRange[1], secondRange[0]..secondRange[1]);
                });
        }
    }
}
