namespace Advent_of_Code_22.Problems
{
    public interface IProblem<T, U>
    {
        public T DoPartA();

        public U DoPartB();
    }
}
