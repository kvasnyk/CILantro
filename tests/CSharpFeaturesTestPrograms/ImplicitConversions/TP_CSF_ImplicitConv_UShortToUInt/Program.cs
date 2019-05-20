using System;

namespace TP_CSF_ImplicitConv_UShortToUInt
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort s = ushort.Parse(Console.ReadLine());
            uint n = s;
            Console.WriteLine(n);
        }
    }
}