using System;

namespace TP_CSF_IntegerLiterals_LongHex
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = 0xfffffffffffl;
            var n2 = 0x00L;
            var n3 = -0X01L;
            var n4 = -0xbcdl;
            var n5 = 0X12345l;
            var n6 = -0x43252fbbbbL;
            var n7 = 0x134l;
            var n8 = -0XFFFl;
            var n9 = -0xfbcd1l;
            var n10 = 0xffffbbbbL;

            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);
            Console.WriteLine(n7);
            Console.WriteLine(n8);
            Console.WriteLine(n9);
            Console.WriteLine(n10);
        }
    }
}