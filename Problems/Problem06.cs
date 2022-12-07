using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_22.Problems
{
    public class Problem06 : IProblem<int, int>
    {
        public int DoPartA()
        {
            return CharacterProcessed(4);
        }

        public int DoPartB()
        {
            return CharacterProcessed(14);
        }

        private int CharacterProcessed(int distinctChars)
        {
            var line = Utils.InputToStringArray("06").Single();

            var que = new Queue<char>();
            var i = 0;

            foreach (var item in line)
            {
                que.Enqueue(item);
                i++;

                if (que.Count() == distinctChars)
                {
                    if (que.Distinct().Count() == distinctChars)
                        return i;

                    que.Dequeue();
                }
            }

            return 0;
        }
    }
}
