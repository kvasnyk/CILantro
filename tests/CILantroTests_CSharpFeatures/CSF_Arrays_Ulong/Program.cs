using System;

namespace CSF_Arrays_Ulong
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = byte.Parse(Console.ReadLine());

            var arr = new ulong[n];

            for (int i = 0; i < n; i++)
                arr[i] = ulong.Parse(Console.ReadLine());

            for (int i = n - 1; i >= 0; i--)
                Console.WriteLine(arr[i]);
        }
    }
}