using System;

namespace TP_CSF_Decisions_If
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var result = n.ToString();
            if (n > 0) result = "+" + n.ToString();

            Console.WriteLine(result);
        }
    }
}