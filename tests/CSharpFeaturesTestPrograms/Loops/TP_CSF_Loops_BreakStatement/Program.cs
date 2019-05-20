using System;

namespace TP_CSF_Loops_BreakStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;

            while(true)
            {
                var n = int.Parse(Console.ReadLine());
                sum += n;

                if (n == 0) break;
            }

            Console.WriteLine(sum);
        }
    }
}