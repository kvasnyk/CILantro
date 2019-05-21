using System;

namespace CSF_Inheritance_CallAbstractClassConstructor
{
    public abstract class A
    {
        private int _n;

        protected A(int n)
        {
            _n = n;
        }

        public void WriteN()
        {
            Console.WriteLine(_n);
        }
    }

    public class B : A
    {
        public B(int n)
            : base(n + 1)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var @int = int.Parse(Console.ReadLine());
            var b = new B(@int);
            b.WriteN();
        }
    }
}