using System;

namespace CSF_Operators_Add_Float64
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = double.Parse(data[0]);
            var b = double.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}