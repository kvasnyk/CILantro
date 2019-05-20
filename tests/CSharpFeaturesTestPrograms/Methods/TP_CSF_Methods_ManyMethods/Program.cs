using System;

namespace TP_CSF_Methods_ManyMethods
{
    public class Computer
    {
        private int _a;
        private int _b;
        private int _c;

        public Computer(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public int Compute()
        {
            var a = _a;
            var b = _b;
            var c = _c;
            var ab = Multiply2(a, b);
            var ac = Multiply2(a, c);
            var bc = Multiply2(b, c);
            var abc = Multiply3(a, b, c);

            return Add7(a, b, c, ab, ac, bc, abc);
        }

        private int Multiply2(int a, int b)
        {
            return a * b;
        }

        private int Multiply3(int a, int b, int c)
        {
            return a * Multiply2(b, c);
        }

        private int Add2(int a, int b)
        {
            return a + b;
        }

        private int Add3(int a, int b, int c)
        {
            return Add2(a, b) + c;
        }

        private int Add4(int a, int b, int c, int d)
        {
            return Add2(a, b) + Add2(c, d);
        }

        private int Add7(int a, int b, int c, int d, int e, int f, int g)
        {
            return Add3(a, b, c) + Add4(d, e, f, g);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var instance = new Computer(a, b, c);
            Console.WriteLine(instance.Compute());
        }
    }
}