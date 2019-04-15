using System;

namespace CSF_Operators_Add_Int8
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = sbyte.Parse(data[0]);
            var b = sbyte.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}