using System;

namespace TP_CSF_ImplicitConv_SByteToShort
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte s = sbyte.Parse(Console.ReadLine());
            short n = s;
            Console.WriteLine(n);
        }
    }
}