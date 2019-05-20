using System;

namespace TP_CSF_Arrays_JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = short.Parse(Console.ReadLine());
            var array = new int[n][];

            for(int i = 0; i < n; i++)
            {
                var m = short.Parse(Console.ReadLine());
                array[i] = new int[m];
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}