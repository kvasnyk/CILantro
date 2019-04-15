using System;

namespace CSF_Operators_Add_Byte
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = byte.Parse(data[0]);
            var b = byte.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}