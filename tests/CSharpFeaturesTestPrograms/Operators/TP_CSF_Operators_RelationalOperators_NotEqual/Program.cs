using System;

namespace TP_CSF_Operators_RelationalOperators_NotEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            var result = a != b;

            Console.WriteLine(result);
        }
    }
}