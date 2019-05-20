using System;

namespace TP_CSF_Enums_EnumWithAssignedValues
{
    public enum Day
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var day = Enum.Parse(typeof(Day), n.ToString());
            Console.WriteLine(day);
        }
    }
}