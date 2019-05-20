using System;

namespace TP_CSF_Operators_BitwiseOperators_Not
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());

            var result = ~a;
            Console.WriteLine(result);
        }
    }
}