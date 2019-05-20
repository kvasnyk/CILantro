using System;

namespace TP_CSF_ImplicitConv_LongToDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            long l = long.Parse(Console.ReadLine());
            decimal d = l;
            Console.WriteLine(d);
        }
    }
}