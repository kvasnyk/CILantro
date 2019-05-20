using System;

namespace TP_CSF_ImplicitConv_ByteToUShort
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = byte.Parse(Console.ReadLine());
            ushort s = b;
            Console.WriteLine(s);
        }
    }
}