using System;

namespace CSF_Operators_Logical2
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

            var c = a && b;
            var d = a || b;

            var x = !a && c || b && !d;
            Console.WriteLine(x);
        }
    }
}