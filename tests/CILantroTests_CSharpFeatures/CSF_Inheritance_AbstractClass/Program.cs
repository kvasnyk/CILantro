using System;

namespace CSF_Inheritance_AbstractClass
{
    public abstract class Calc
    {
        protected abstract char GetOperator();

        protected abstract int Calculate(int a, int b);

        public void Write(int a, int b)
        {
            Console.WriteLine($"a {GetOperator()} b = {Calculate(a, b)}");
        }
    }

    public class CalcAdd : Calc
    {
        protected override char GetOperator()
        {
            return '+';
        }

        protected override int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public class CalcSub : Calc
    {
        protected override char GetOperator()
        {
            return '-';
        }

        protected override int Calculate(int a, int b)
        {
            return a - b;
        }
    }

    public class CalcMul : Calc
    {
        protected override char GetOperator()
        {
            return '*';
        }

        protected override int Calculate(int a, int b)
        {
            return a * b;
        }
    }

    public class CalcDiv : Calc
    {
        protected override char GetOperator()
        {
            return '/';
        }

        protected override int Calculate(int a, int b)
        {
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            var add = new CalcAdd();
            var sub = new CalcSub();
            var mul = new CalcMul();
            var div = new CalcDiv();

            add.Write(a, b);
            sub.Write(a, b);
            mul.Write(a, b);
            div.Write(a, b);
        }
    }
}