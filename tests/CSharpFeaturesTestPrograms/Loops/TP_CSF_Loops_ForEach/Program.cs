using System;

namespace TP_CSF_Loops_ForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = short.Parse(Console.ReadLine());

            var array = new int[n];

            for (int i = 0; i < n; i++) array[i] = int.Parse(Console.ReadLine());

            foreach(var element in array)
            {
                Console.WriteLine(element);
            }
        }
    }
}