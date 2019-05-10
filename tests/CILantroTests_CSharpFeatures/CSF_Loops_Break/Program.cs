using System;

namespace CSF_Loops_Break
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
            } while (n != 0);

            Console.WriteLine(sum);
        }
    }
}