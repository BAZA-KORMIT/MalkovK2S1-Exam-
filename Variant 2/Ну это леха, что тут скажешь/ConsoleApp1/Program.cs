using ConsoleApp1;
using Lab6to8;

namespace Zachet
{
    public static class Program
    {
        public static void Main()
        {
            MyStack<int> first = new MyStack<int>(100);
            MyStack<int> second = new MyStack<int>(100);

            first.Push(1);
            first.Push(2);
            first.Push(3);
            first.Push(4);
            first.Push(9999);

            second.Push(5);
            second.Push(6);
            second.Push(7);
            second.Push(8);
            second.Push(9);

            Third<int> res = new Third<int>(first, second);
            var sol = res.GetSolution();
            while (!sol.IsEmpty())
                Console.WriteLine(sol.Dequeue());

            Console.WriteLine();

            string s = "abcabb", w = "bgabbc";
            Second second1 = new Second(s, w);
            Console.WriteLine(second1.GetResult());
        }
    }
}