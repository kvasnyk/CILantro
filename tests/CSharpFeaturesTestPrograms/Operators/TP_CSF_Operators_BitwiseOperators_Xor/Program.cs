using System;

namespace TP_CSF_Operators_BitwiseOperators_Xor
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            var result = a ^ b;
            Console.WriteLine(result);
        }
    }
}