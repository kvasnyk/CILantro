using System;

namespace TP_CSF_ExplicitConv_ShortToSByte
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = short.Parse(Console.ReadLine());
            sbyte b = (sbyte)s;
            Console.WriteLine(b);
        }
    }
}