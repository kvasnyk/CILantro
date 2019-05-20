using System;

namespace TP_CSF_Classes_ConstructorWithCustomArguments
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

    public class IntAdder
    {
        public IntPair _pair;

        public IntAdder(IntPair pair)
        {
            _pair = pair;
        }

        public int GetSum()
        {
            return _pair.GetA() + _pair.GetB();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var pair = new IntPair(a, b);
            var adder = new IntAdder(pair);
            Console.WriteLine(adder.GetSum());
        }
    }
}