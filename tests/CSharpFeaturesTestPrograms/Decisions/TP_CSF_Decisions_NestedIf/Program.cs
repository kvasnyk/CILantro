using System;

namespace TP_CSF_Decisions_NestedIf
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            if(a < 0)
            {
                Console.WriteLine("negative");

                if (b < 0) Console.WriteLine("negative");
                else if (b > 0) Console.WriteLine("positive");
                else Console.WriteLine("zero");
            }
            else if(a > 0)
            {
                Console.WriteLine("positive");

                if (b < 0) Console.WriteLine("negative");
                else if (b > 0) Console.WriteLine("positive");
                else Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("zero");

                if (b < 0) Console.WriteLine("negative");
                else if (b > 0) Console.WriteLine("positive");
                else Console.WriteLine("zero");
            }
        }
    }
}