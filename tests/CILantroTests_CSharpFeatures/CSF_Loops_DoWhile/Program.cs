using System;

namespace CSF_Loops_DoWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = sbyte.Parse(Console.ReadLine());

            long result = 1;

            do
            {
                Console.WriteLine(result);
                result *= 2;
                n--;
            } while (n >= 0);
        }
    }
}