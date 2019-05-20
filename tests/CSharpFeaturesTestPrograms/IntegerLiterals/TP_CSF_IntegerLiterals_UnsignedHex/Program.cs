using System;

namespace TP_CSF_IntegerLiterals_UnsignedHex
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = 0x0u;
            var n2 = 0X13432u;
            var n3 = 0XffbU;
            var n4 = 0xffcdu;
            var n5 = 0x999u;
            var n6 = 0X132fbcU;
            var n7 = 0xffffffffU;
            var n8 = 0x1234u;
            var n9 = 0xffccddU;
            var n10 = 0X98ffu;

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