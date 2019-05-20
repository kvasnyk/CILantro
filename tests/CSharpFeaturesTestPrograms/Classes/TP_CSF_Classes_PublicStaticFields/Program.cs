using System;

namespace TP_CSF_Classes_PublicStaticFields
{
    public class Counter
    {
        public static int _counter = 0;

        public Counter()
        {
            _counter++;
        }
    }

    public class Adder
    {
        public static int _sum = 0;

        public Adder(int n)
        {
            _sum += n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                var counter = new Counter();
                var adder = new Adder(i);
            }

            Console.WriteLine(Counter._counter);
            Console.WriteLine(Adder._sum);
        }
    }
}