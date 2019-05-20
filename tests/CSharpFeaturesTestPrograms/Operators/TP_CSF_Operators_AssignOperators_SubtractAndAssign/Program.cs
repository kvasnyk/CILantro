using System;

namespace TP_CSF_Operators_AssignOperators_SubtractAndAssign
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            var result = a;
            result -= b;
            Console.WriteLine(result);
        }
    }
}