using System;

namespace TP_CSF_Arrays_1DArrayInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberNames = new string[]
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "ten"
            };

            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(numberNames[n]);
        }
    }
}