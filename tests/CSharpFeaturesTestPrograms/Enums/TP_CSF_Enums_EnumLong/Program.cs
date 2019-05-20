using System;

namespace TP_CSF_Enums_EnumLong
{
    public enum LongEnum : long
    {
        A = 3,
        B = 4,
        C = 5,
        D = 6,
        E = 7,
        F = 8,
        G = 9,
        H = 10,
        I = 11,
        J = 12
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var e = Enum.Parse(typeof(LongEnum), n.ToString());
            Console.WriteLine(e);
        }
    }
}