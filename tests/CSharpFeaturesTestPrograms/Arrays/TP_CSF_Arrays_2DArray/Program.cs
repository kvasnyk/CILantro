using System;

namespace TP_CSF_Arrays_2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var numbers = new int[n, m];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    numbers[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write(numbers[i, j]);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}