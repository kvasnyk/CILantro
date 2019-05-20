using System;

namespace TP_CSF_Decisions_ConditionalAssignOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = bool.Parse(Console.ReadLine());

            var result = b ? "It's true!" : "It's false!";
            Console.WriteLine(result);
        }
    }
}