using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_22.Problems
{
    public class Problem05 : IProblem<string, string>
    {
        public string DoPartA()
        {
            var crates = ReadStock();
            var commands = ReadCommands();

            crates = RunCommands(crates, commands, false);

            var cratesOnTop = crates.OrderBy(crate => crate.Key).Select(crate => crate.Value.FirstOrDefault().ToString());

            return string.Join(string.Empty, cratesOnTop);
        }

        public string DoPartB()
        {
            var crates = ReadStock();
            var commands = ReadCommands();

            crates = RunCommands(crates, commands, true);

            var cratesOnTop = crates.OrderBy(crate => crate.Key).Select(crate => crate.Value.FirstOrDefault().ToString());

            return string.Join(string.Empty, cratesOnTop);
        }

        private Dictionary<int, Stack<char>> ReadStock()
        {
            var lines = Utils.InputToStringArray("05_crates");
            var crates = new Dictionary<int, Stack<char>>();

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
                            crates[columnNo].Push(line[i]);
                        else
                            crates[columnNo] = new Stack<char>(new[] { line[i] });
                    }
                }
            }

            foreach (var crate in crates)
            {
                var stack = crate.Value;

                // Turn upside down
                stack = new Stack<char>(stack);

                crates[crate.Key] = stack;
            }

            return crates;
        }

        private List<(int pieces, int colFrom, int colTo)> ReadCommands()
        {
            var lines = Utils.InputToStringArray("05");
            var commands = new List<(int, int, int)>();

            foreach (var line in lines)
            {
                var numbersInLine = Regex.Matches(line, @"\d+");
                var command = numbersInLine.Select(match => Convert.ToInt32(match.Value)).ToArray();
                commands.Add((command[0], command[1], command[2]));
            }

            return commands;
        }

        private Func<Dictionary<int, Stack<char>>, List<(int pieces, int colFrom, int colTo)>, bool, Dictionary<int, Stack<char>>> RunCommands =>
            (crates, commands, moveTogether) =>
            {
                foreach (var command in commands)
                {
                    if (moveTogether)
                    {
                        var helperStack = new Stack<char>();

                        MoveCrates(crates[command.colFrom], helperStack, command.pieces);
                        MoveCrates(helperStack, crates[command.colTo], command.pieces);
                    }
                    else
                        MoveCrates(crates[command.colFrom], crates[command.colTo], command.pieces);
                }

                return crates;
            };

        private void MoveCrates(Stack<char> from, Stack<char> to, int pieces)
        {
            for (int i = 0; i < pieces; i++)
                to.Push(from.Pop());
        }
    }
}
