using System;

namespace TP_CSF_Methods_ManyRecursiveMethods
{
    public class TestClass
    {
        private int _n;

        public TestClass(int n)
        {
            _n = n;
        }

        public int Compute()
        {
            return ComputeZero(_n);
        }

        private int ComputeZero(int n)
        {
            if (n == 0) return 0;

            return ComputeN(n) - n;
        }

        private int ComputeN(int n)
        {
            return ComputeZero(n - 1) + n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var instance = new TestClass(n);
            Console.WriteLine(instance.Compute());
        }
    }
}