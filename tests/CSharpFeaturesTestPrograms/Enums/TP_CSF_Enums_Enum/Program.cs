using System;

namespace TP_CSF_Enums_Enum
{
    public enum Color
    {
        Red,
        Green,
        Blue,
        Black,
        White,
        Yellow,
        Purple,
        Pink
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var e = Enum.Parse(typeof(Color), Console.ReadLine());
            Console.WriteLine(e);
        }
    }
}