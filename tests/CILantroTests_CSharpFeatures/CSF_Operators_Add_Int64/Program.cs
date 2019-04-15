using System;

namespace CSF_Operators_Add_Int64
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = long.Parse(data[0]);
            var b = long.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}