using System;

namespace TP_CSF_Inheritance_ProtectedConstructor
{
    public class A
    {
        protected int _n;

        protected A(int n)
        {
            _n = n;
        }
    }

    public class B : A
    {
        public B(int n) : base(n) { }

        public int GetN() { return _n; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var b = new B(n);
            Console.WriteLine(b.GetN());
        }
    }
}