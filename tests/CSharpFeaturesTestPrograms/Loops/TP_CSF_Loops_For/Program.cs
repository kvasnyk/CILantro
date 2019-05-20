using System;

namespace TP_CSF_Loops_For
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var sum = 0;
            for(int i = 0; i <= n; i++)
            {
                sum += i;
            }

            Console.WriteLine(sum);
        }
    }
}