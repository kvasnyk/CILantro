using System;

namespace CSF_Loops_While
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = short.Parse(Console.ReadLine());

            while(n >= 0)
            {
                Console.WriteLine(n);
                n--;
            }
        }
    }
}