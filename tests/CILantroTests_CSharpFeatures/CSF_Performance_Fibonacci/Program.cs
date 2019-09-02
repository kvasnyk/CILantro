using System;

namespace CSF_Performance_Fibonacci
{
    class Program
    {
        static long Fibonacci(int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var fn = Fibonacci(n);
            Console.WriteLine(fn);
        }
    }
}