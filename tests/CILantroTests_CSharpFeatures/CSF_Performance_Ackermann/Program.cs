using System;

namespace CSF_Performance_Ackermann
{
    class Program
    {
        static int Ackermann(int m, int n)
        {
            if (m == 0)
                return n + 1;
            if (m > 0 && n == 0)
                return Ackermann(m - 1, 1);
            if (m > 0 && n > 0)
                return Ackermann(m - 1, Ackermann(m, n - 1));

            return 1;
        }

        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var ack = Ackermann(m, n);
            Console.WriteLine(ack);
        }
    }
}