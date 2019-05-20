using System;

namespace TP_CSF_Arrays_1DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = new int[n];

            for (int i = 0; i < n; i++) numbers[i] = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) Console.WriteLine(numbers[i]);
        }
    }
}