using System;

namespace TP_CSF_Loops_DoWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;

            int n;
            do
            {
                n = int.Parse(Console.ReadLine());
                sum += n;
            }
            while (n != 0);

            Console.WriteLine(sum);
        }
    }
}