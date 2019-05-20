using System;

namespace TP_CSF_Inheritance_BaseConstructor
{
    public class A
    {
        protected int _int1;

        protected A(int int1)
        {
            _int1 = int1;
        }
    }

    public class B : A
    {
        private int _int2;

        public B(int int1, int int2) : base(int1)
        {
            _int2 = int2;
        }

        public int GetInt1() { return _int1; }

        public int GetInt2() { return _int2; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var int1 = int.Parse(Console.ReadLine());
            var int2 = int.Parse(Console.ReadLine());
            var b = new B(int1, int2);
            Console.WriteLine(b.GetInt1());
            Console.WriteLine(b.GetInt2());
        }
    }
}