using System;

namespace TP_CSF_Polymorphism_ExistingClassWithVirtualMethod
{
    public class A : Object
    {
        private int _n;

        public A(int n) { _n = n; }

        public override string ToString()
        {
            return _n.ToString();
        }
    }

    public class B : A
    {
        public B(int n) : base(n) { }

        public override string ToString()
        {
            return 1.ToString();
        }
    }

    public class C : B
    {
        public C(int n) : base(n) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            object a = new A(n);
            object b = new B(n);
            object c = new C(n);

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());
        }
    }
}