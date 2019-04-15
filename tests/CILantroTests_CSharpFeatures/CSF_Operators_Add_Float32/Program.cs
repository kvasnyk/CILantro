using System;

namespace CSF_Operators_Add_Float32
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = float.Parse(data[0]);
            var b = float.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}