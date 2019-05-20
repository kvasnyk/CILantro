using System;

namespace TP_CSF_Decisions_EnumSwitch
{
    public enum DayOfTheWeek : sbyte
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
            var d = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), n.ToString());

            switch(d)
            {
                case DayOfTheWeek.Monday:
                    Console.WriteLine("Monday");
                    break;
                case DayOfTheWeek.Tuesday:
                    Console.WriteLine("Tuesday");
                    break;
                case DayOfTheWeek.Wednesday:
                    Console.WriteLine("Wednesday");
                    break;
                case DayOfTheWeek.Thursday:
                    Console.WriteLine("Thursday");
                    break;
                case DayOfTheWeek.Friday:
                    Console.WriteLine("Friday");
                    break;
                case DayOfTheWeek.Saturday:
                    Console.WriteLine("Saturday");
                    break;
                case DayOfTheWeek.Sunday:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("not a day");
                    break;
            }
        }
    }
}