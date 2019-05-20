using System;

namespace TP_CSF_Polymorphism_ClassWithVirtualMethod
{
    public class A
    {
        private int _n;

        public A(int n) { _n = n; }

        public virtual int GetValue() { return _n; }
    }

    public class B : A
    {
        public B(int n) : base(n) { }

        public override int GetValue()
        {
            return base.GetValue() + 1;
        }
    }

    public class C : B
    {
        public C(int n) : base(n) { }

        public override int GetValue()
        {
            return base.GetValue() + 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            A a = new A(n);
            A b = new B(n);
            A c = new C(n);

            Console.WriteLine(a.GetValue());
            Console.WriteLine(b.GetValue());
            Console.WriteLine(c.GetValue());
        }
    }
}