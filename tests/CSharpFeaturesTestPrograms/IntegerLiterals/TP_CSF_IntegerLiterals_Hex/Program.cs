using System;

namespace TP_CSF_IntegerLiterals_Hex
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = 0x4325;
            var n2 = 0x0;
            var n3 = -0x432432;
            var n4 = -0x1321;
            var n5 = 0xfab;
            var n6 = -0x9ff;
            var n7 = 0x991f;
            var n8 = -0Xabcdef;
            var n9 = 0X2fd;
            var n10 = -0x99bc;

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