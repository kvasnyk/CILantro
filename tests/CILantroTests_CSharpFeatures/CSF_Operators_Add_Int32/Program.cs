using System;

namespace CSF_Operators_Add_Int32
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');

            var a = int.Parse(data[0]);
            var b = int.Parse(data[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}