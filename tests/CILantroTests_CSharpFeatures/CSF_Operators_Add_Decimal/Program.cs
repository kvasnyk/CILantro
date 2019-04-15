using System;

namespace CSF_Operators_Add_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = decimal.Parse(data[0]);
            var b = decimal.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}