using System;

namespace CSF_Loops_NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            var n = int.Parse(line[0]);
            var m = int.Parse(line[1]);

            for (int i = 0; i <= n; i++)
            {
                var j = 0;
                while (j <= m)
                {
                    var r = i * j;
                    Console.Write(r.ToString().PadLeft(6, ' '));
                    j++;
                }

                Console.WriteLine();
            }
        }
    }
}