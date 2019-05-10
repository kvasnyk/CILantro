using System;

namespace CSF_Loops_Continue
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;

            while (true)
            {
                var n = int.Parse(Console.ReadLine());

                if (n == 0)
                    break;

                if (n < 0)
                    continue;

                sum += n;
            }

            Console.WriteLine(sum);
        }
    }
}