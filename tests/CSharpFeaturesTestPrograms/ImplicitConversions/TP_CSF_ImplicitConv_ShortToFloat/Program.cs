using System;

namespace TP_CSF_ImplicitConv_ShortToFloat
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = short.Parse(Console.ReadLine());
            float f = s;
            Console.WriteLine(f);
        }
    }
}