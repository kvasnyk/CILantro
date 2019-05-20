using System;

namespace TP_CSF_Inheritance_AbstractClass
{
    public abstract class Calculator
    {
        protected int _a;

        protected int _b;

        public Calculator(int a, int b) { _a = a; _b = b; }

        public abstract int Calculate();
    }

    public class SumCalculator : Calculator
    {
        public SumCalculator(int a, int b) : base(a, b) { }

        public override int Calculate()
        {
            return _a + _b;
        }
    }

    public class DifferenceCalculator : Calculator
    {
        public DifferenceCalculator(int a, int b) : base(a, b) { }

        public override int Calculate()
        {
            return _a - _b;
        }
    }

    public class ProductCalculator : Calculator
    {
        public ProductCalculator(int a, int b) : base(a, b) { }

        public override int Calculate()
        {
            return _a * _b;
        }
    }

    public class QuotientCalculator : Calculator
    {
        public QuotientCalculator(int a, int b) : base(a, b) { }

        public override int Calculate()
        {
            return _a / _b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            var sum = new SumCalculator(a, b);
            var difference = new DifferenceCalculator(a, b);
            var product = new ProductCalculator(a, b);
            var quotient = new QuotientCalculator(a, b);

            Console.WriteLine(sum.Calculate());
            Console.WriteLine(difference.Calculate());
            Console.WriteLine(product.Calculate());
            Console.WriteLine(quotient.Calculate());
        }
    }
}