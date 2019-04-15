using System;

namespace CSF_Operators_Add_Int16
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = short.Parse(data[0]);
            var b = short.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}