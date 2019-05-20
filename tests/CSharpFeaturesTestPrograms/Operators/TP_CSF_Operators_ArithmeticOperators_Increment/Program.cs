using System;

namespace TP_CSF_Operators_ArithmeticOperators_Increment
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(++n);
            Console.WriteLine(n++);
        }
    }
}