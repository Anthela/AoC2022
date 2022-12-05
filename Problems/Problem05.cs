using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_22.Problems
{
    public class Problem05 : IProblem<string, int>
    {
        public string DoPartA()
        {
            var lines = Utils.InputToStringArray("05_crates_mini");
            var crates = new Dictionary<int, Queue<char>>();

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if ((i + 1) % 2 == 0 && !line[i].Equals(' '))
                    {
                        // 2  - col 1
                        // 6  - col 2
                        // 10 - col 3
                        // 14 - col 4
                        var columnNo = (i + 1 + 2) / 4;

                        if (crates.ContainsKey(columnNo))
                            crates[columnNo].Enqueue(line[i]);
                        else
                            crates[columnNo] = new Queue<char>(new[] { line[i] });
                    }
                }
            }

            foreach (var crate in crates)
            {
                var queue = crate.Value;

                queue = new Queue<char>(queue.Reverse());

                crates[crate.Key] = queue;
            }


            return "";
        }

        public int DoPartB()
        {


            return 0;
        }
    }
}
