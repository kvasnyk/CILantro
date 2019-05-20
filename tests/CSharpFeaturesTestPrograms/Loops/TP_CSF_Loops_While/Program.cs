using System;

namespace TP_CSF_Loops_While
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;

            var n = int.Parse(Console.ReadLine());
            while(n != 0)
            {
                sum += n;
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sum);
        }
    }
}