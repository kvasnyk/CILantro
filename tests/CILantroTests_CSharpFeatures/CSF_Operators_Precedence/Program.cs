using System;

namespace CSF_Operators_Precedence
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());

            var r1 = a + b - c * d;
            var r2 = (a + b) * c - d;
            var r3 = a++ - --b * (c / d);
            var r4 = a | (b + c & d);
            var r5 = (a << b) + c >> d;
            var r6 = a == b && c == a || (b ^ c) > 0;
            var r7 = a > b && c < d && 1 != 0;
            var r8 = a > b && b > c && c > d;
            var r9 = a * b - c / d + a - b * c + d / a - b + c * d;
            var r10 = a++ * b-- / c++ * d--;

            Console.WriteLine(r1);
            Console.WriteLine(r2);
            Console.WriteLine(r3);
            Console.WriteLine(r4);
            Console.WriteLine(r5);
            Console.WriteLine(r6);
            Console.WriteLine(r7);
            Console.WriteLine(r8);
            Console.WriteLine(r9);
            Console.WriteLine(r10);
        }
    }
}