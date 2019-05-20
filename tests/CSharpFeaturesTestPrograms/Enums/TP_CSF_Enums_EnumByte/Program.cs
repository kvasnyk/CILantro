using System;

namespace TP_CSF_Enums_EnumByte
{
    public enum ByteEnum : byte
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b = byte.Parse(Console.ReadLine());
            var e = Enum.Parse(typeof(ByteEnum), b.ToString());
            Console.WriteLine(e);
        }
    }
}