using System;

namespace TP_CSF_Loops_NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            for(int i = 0; i <= n; i++)
            {
                for(int j = 0; j <= m; j++)
                {
                    Console.WriteLine(i.ToString() + " " + j.ToString());
                }
            }
        }
    }
}