using Advent_of_Code_22;
using Advent_of_Code_22.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_22.Problems
{
    public class Problem03 : IProblem<int, int>
    {
        public int DoPartA()
        {
            var lines = Utils.InputToStringArray("03");
            var sum = 0;

            foreach (var line in lines)
            {
                var firstHalf = line.Substring(0, line.Length / 2);
                var secondHalf = line.Substring(line.Length / 2);

                var commonItem = firstHalf.Distinct().Intersect(secondHalf.Distinct()).Single();

                sum += CalculateValueOfItem(commonItem);
            }

            return sum;
        }

        public int DoPartB()
        {
            var lines = Utils.InputToStringArray("03").ToArray();
            var items = new List<List<char>>();
            var sum = 0;

            for (int i = 0; i < lines.Count(); i++)
            {
                items.Add(lines[i].Distinct().ToList());

                if ((i + 1) % 3 == 0)
                {
                    var commonItem = items[0].Intersect(items[1]).Intersect(items[2]).Single();

                    sum += CalculateValueOfItem(commonItem);

                    items.Clear();
                }
            }

            return sum;
        }

        private int CalculateValueOfItem(char item)
        {
            int value;

            // Uppercase char
            if (item < 91)
                value = item - 65 + 27;
            else // Lowercase char
                value = item - 97 + 1;

            return value;
        }
    }
}
