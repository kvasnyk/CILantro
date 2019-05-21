using System;

namespace CSF_Inheritance_CallAbstractClassConstructor2
{
    public abstract class A
    {
        protected int _n;

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
            _n++;
        }
    }

    public class C : B
    {
        public C(int n)
            : base(n + 2)
        {
            _n++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var @int = int.Parse(Console.ReadLine());
            var b = new B(@int);
            b.WriteN();
            var c = new C(@int);
            c.WriteN();
        }
    }
}