using System;

namespace TP_CSF_Inheritance_ProtectedMethod
{
    public class A
    {
        private int _n;

        protected A(int n)
        {
            _n = n;
        }

        protected int GetValue() { return _n; }
    }

    public class B : A
    {
        public B(int n) : base(n) { }

        public int GetN() { return GetValue(); }
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