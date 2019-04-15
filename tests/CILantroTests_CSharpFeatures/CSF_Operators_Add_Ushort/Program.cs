using System;

namespace CSF_Operators_Add_Ushort
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = ushort.Parse(data[0]);
            var b = ushort.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}