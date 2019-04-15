using System;

namespace CSF_Operators_Add_Char
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = char.Parse(data[0]);
            var b = char.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}