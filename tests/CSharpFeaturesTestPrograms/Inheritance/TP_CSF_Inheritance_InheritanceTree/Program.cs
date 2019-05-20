using System;

namespace TP_CSF_Inheritance_InheritanceTree
{
    public class A
    {
        private int _n;

        protected A(int n) { _n = n; }

        public int GetN() { return _n; }
    }

    public class B : A
    {
        protected B(int n) : base(n) { }
    }

    public class C : A
    {
        protected C(int n) : base(n) { }
    }

    public class D : B
    {
        public D(int n) : base(n) { }
    }

    public class E : B
    {
        public E(int n) : base(n) { }
    }

    public class F : C
    {
        public F(int n) : base(n) { }
    }

    public class G : C
    {
        public G(int n) : base(n) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var d = new D(n);
            var e = new E(n);
            var f = new F(n);
            var g = new G(n);

            Console.WriteLine(d.GetN());
            Console.WriteLine(e.GetN());
            Console.WriteLine(f.GetN());
            Console.WriteLine(g.GetN());
        }
    }
}