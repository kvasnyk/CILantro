using System;

namespace TP_CSF_Methods_CustomArguments
{
    public class IntPair
    {
        private int _a;

        private int _b;

        public IntPair(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int GetA() { return _a; }

        public int GetB() { return _b; }
    }

    class Program
    {
        private static int Sum(IntPair pair)
        {
            return pair.GetA() + pair.GetB();
        }

        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var pair = new IntPair(a, b);
            Console.WriteLine(Sum(pair));
        }
    }
}