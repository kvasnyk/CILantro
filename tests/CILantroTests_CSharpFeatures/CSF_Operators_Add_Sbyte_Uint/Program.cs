using System;

namespace CSF_Operators_Add_Sbyte_Uint
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = sbyte.Parse(data[0]);
            var b = uint.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}