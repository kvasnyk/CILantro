using System;

namespace TP_CSF_Methods_RecursiveMethod
{
    public class RecursiveMethodClass
    {
        public static int ComputeSum(int n)
        {
            if (n == 0) return 0;
            return n + ComputeSum(n - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(RecursiveMethodClass.ComputeSum(n));
        }
    }
}