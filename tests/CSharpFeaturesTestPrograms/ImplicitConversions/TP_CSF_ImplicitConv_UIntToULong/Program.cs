using System;

namespace TP_CSF_ImplicitConv_UIntToULong
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            ulong l = n;
            Console.WriteLine(l);
        }
    }
}