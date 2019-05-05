using System;

namespace CSF_Operators_Logical
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = bool.Parse(Console.ReadLine());
            var b = bool.Parse(Console.ReadLine());

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(!a);
            Console.WriteLine(!b);
            Console.WriteLine(a && b);
            Console.WriteLine(a || b);
        }
    }
}