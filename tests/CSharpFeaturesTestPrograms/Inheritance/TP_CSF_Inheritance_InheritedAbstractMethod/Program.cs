using System;

namespace TP_CSF_Inheritance_InheritedAbstractMethod
{
    public abstract class A
    {
        protected int _n;

        public A(int n) { _n = n; }

        public abstract int GetN();
    }

    public class B : A
    {
        public B(int n) : base(n) { }

        public override int GetN()
        {
            return _n;
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
            var c = new C(n);
            Console.WriteLine(c.GetN());
        }
    }
}