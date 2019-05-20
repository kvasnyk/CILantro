using System;

namespace TP_CSF_Inheritance_InheritanceChain
{
    public class A
    {
        private int _n;

        public A(int n) { _n = n; }

        public int GetField() { return _n; }
    }

    public class B : A
    {
        public B(int n) : base(n) { }
    }

    public class C : B
    {
        public C(int n) : base(n) { }
    }

    public class D : C
    {
        public D(int n) : base(n) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var a = new A(n);
            var b = new B(n);
            var c = new C(n);
            var d = new D(n);

            Console.WriteLine(a.GetField());
            Console.WriteLine(b.GetField());
            Console.WriteLine(c.GetField());
            Console.WriteLine(d.GetField());
        }
    }
}