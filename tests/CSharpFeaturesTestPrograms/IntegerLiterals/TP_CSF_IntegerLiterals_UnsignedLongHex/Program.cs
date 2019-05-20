using System;

namespace TP_CSF_IntegerLiterals_UnsignedLongHex
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = 0xfffffffful;
            var n2 = 0x0UL;
            var n3 = 0x88ffbblu;
            var n4 = 0x123Ul;
            var n5 = 0x14323245435LU;
            var n6 = 0XffaaablU;
            var n7 = 0Xaabb77LU;
            var n8 = 0xaBBfuL;
            var n9 = 0x1321UL;
            var n10 = 0XABCDEFul;

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