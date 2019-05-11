using System;

namespace CSF_Arrays_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = byte.Parse(Console.ReadLine());

            var arr = new string[n];

            for (int i = 0; i < n; i++)
                arr[i] = Console.ReadLine();

            for (int i = n - 1; i >= 0; i--)
                Console.WriteLine(arr[i]);
        }
    }
}