using System;

namespace TP_CSF_Variables_8Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());
            var e = int.Parse(Console.ReadLine());
            var f = int.Parse(Console.ReadLine());
            var g = int.Parse(Console.ReadLine());
            var h = int.Parse(Console.ReadLine());

            var sum = a + b + c + d + e + f + g + h;

            Console.WriteLine(sum);
        }
    }
}