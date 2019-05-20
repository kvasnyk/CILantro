using System;

namespace TP_CSF_Variables_4Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());

            var sum = a + b + c + d;

            Console.WriteLine(sum);
        }
    }
}