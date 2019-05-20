using System;

namespace TP_CSF_Arrays_3DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());
            var z = int.Parse(Console.ReadLine());

            var numbers = new int[x, y, z];

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    for (int k = 0; k < z; k++)
                        numbers[i, j, k] = int.Parse(Console.ReadLine());

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    for (int k = 0; k < z; k++)
                        Console.WriteLine(numbers[i, j, k]);
        }
    }
}