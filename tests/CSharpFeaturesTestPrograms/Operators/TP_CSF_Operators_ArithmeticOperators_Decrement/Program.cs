using System;

namespace TP_CSF_Operators_ArithmeticOperators_Decrement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(--n);
            Console.WriteLine(n--);
        }
    }
}