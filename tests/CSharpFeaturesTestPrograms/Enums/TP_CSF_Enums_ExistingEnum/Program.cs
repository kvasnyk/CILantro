using System;

namespace TP_CSF_Enums_ExistingEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = Enum.Parse(typeof(PlatformID), Console.ReadLine());
            Console.WriteLine(e);
        }
    }
}