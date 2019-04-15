using System;

namespace CSF_Operators_Add_Ulong
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = ulong.Parse(data[0]);
            var b = ulong.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}