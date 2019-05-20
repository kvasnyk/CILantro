using System;

namespace TP_CSF_Methods_Params
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if(n == 0)
            {
                var sum = Add();
                Console.WriteLine(sum);
            }
            else if(n == 1)
            {
                var x1 = int.Parse(Console.ReadLine());
                var sum = Add(x1);
                Console.WriteLine(sum);
            }
            else if(n == 2)
            {
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                var sum = Add(x1, x2);
                Console.WriteLine(sum);
            }
            else if(n == 3)
            {
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                var x3 = int.Parse(Console.ReadLine());
                var sum = Add(x1, x2, x3);
                Console.WriteLine(sum);
            }
            else if(n == 4)
            {
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                var x3 = int.Parse(Console.ReadLine());
                var x4 = int.Parse(Console.ReadLine());
                var sum = Add(x1, x2, x3, x4);
                Console.WriteLine(sum);
            }
            else if(n == 5)
            {
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                var x3 = int.Parse(Console.ReadLine());
                var x4 = int.Parse(Console.ReadLine());
                var x5 = int.Parse(Console.ReadLine());
                var sum = Add(x1, x2, x3, x4, x5);
                Console.WriteLine(sum);
            }
        }

        private static int Add(params int[] numbers)
        {
            var result = 0;
            foreach (var number in numbers) result += number;
            return result;
        }
    }
}