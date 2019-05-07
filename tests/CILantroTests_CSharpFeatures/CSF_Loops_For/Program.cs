using System;

namespace CSF_Loops_For
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            var a = sbyte.Parse(line[0]);
            var b = sbyte.Parse(line[1]);

            var min = a <= b ? a : b;
            var max = a >= b ? a : b;

            for (short i = min; i <= max; i++)
                Console.WriteLine(i);
        }
    }
}