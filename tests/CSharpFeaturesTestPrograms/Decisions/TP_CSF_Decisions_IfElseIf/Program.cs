using System;

namespace TP_CSF_Decisions_IfElseIf
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = char.Parse(Console.ReadLine());

            var result = "symbol";
            if (char.IsDigit(c)) result = "digit";
            else if (char.IsLetter(c)) result = "letter";

            Console.WriteLine(result);
        }
    }
}