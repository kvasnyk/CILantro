using System;

namespace TP_CSF_ExplicitConv_LongToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            long l = long.Parse(Console.ReadLine());
            int n = (int)l;
            Console.WriteLine(n);
        }
    }
}