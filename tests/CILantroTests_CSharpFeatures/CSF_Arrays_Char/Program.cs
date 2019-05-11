using System;

namespace CSF_Arrays_Char
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = byte.Parse(Console.ReadLine());

            var arr = new char[n];

            for (int i = 0; i < n; i++)
                arr[i] = char.Parse(Console.ReadLine());

            for (int i = n - 1; i >= 0; i--)
                Console.WriteLine(arr[i]);
        }
    }
}