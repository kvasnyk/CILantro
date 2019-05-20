using System;

namespace TP_CSF_ExplicitConv_IntToShort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            short s = (short)n;
            Console.WriteLine(s);
        }
    }
}