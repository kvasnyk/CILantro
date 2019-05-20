using System;

namespace TP_CSF_Enums_EnumShort
{
    public enum Month : short
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = short.Parse(Console.ReadLine());
            var e = Enum.Parse(typeof(Month), n.ToString());
            Console.WriteLine(e);
        }
    }
}