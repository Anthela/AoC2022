namespace Advent_of_Code_22.Problems
{
    public class Problem02 : IProblem<int, int>
    {
        public int DoPartA()
        {
            var lines = Utils.InputToStringArray("02");
            IEnumerable<(string enemyMove, string myMove)> moves = lines.Select(line => (line.First().ToString(), line.Last().ToString()));
            // A x C - 1 x 3
            // B x A - 2 x 1
            // C x B - 3 x 2
            var enemyMoves = new List<string> { "A", "B", "C" };
            var myMoves = new List<string> { "X", "Y", "Z" };

            var score = 0;
            foreach (var move in moves)
            {
                var enemyMoveIndex = enemyMoves.FindIndex(m => m.Equals(move.enemyMove));
                var myMoveIndex = myMoves.FindIndex(m => m.Equals(move.myMove));

                score += myMoveIndex + 1;

                if (myMoveIndex == enemyMoveIndex)
                    score += 3;
                else if ((move.myMove.Equals("X") && move.enemyMove.Equals("C")) ||
                         (move.myMove.Equals("Y") && move.enemyMove.Equals("A")) ||
                         (move.myMove.Equals("Z") && move.enemyMove.Equals("B")))
                    score += 6;
            }

            return score;
        }

        public int DoPartB()
        {
            var lines = Utils.InputToStringArray("02");
            IEnumerable<(string enemyMove, string strategy)> moves = lines.Select(line => (line.First().ToString(), line.Last().ToString()));
            // X - lose
            // Y - draw
            // Z - win
            var enemyMoves = new List<string> { "A", "B", "C" };

            var score = 0;

            foreach (var move in moves)
            {
                if (move.strategy.Equals("X"))
                {
                    switch (move.enemyMove)
                    {
                        case "A":
                            score += 3;
                            break;
                        case "B":
                            score++;
                            break;
                        case "C":
                            score += 2;
                            break;
                    }
                }
                else if (move.strategy.Equals("Y"))
                {
                    var enemyMoveIndex = enemyMoves.FindIndex(m => m.Equals(move.enemyMove));
                    score += 3 + enemyMoveIndex + 1;
                }
                else
                {
                    score += 6;

                    switch (move.enemyMove)
                    {
                        case "A":
                            score += 2;
                            break;
                        case "B":
                            score += 3;
                            break;
                        case "C":
                            score++;
                            break;
                    }
                }
            }

            return score;
        }
    }
}
