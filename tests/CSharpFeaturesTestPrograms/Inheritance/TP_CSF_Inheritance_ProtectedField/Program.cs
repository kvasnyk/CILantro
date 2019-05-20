using System;

namespace TP_CSF_Inheritance_ProtectedField
{
    public class A
    {
        protected int _field;
    }

    public class B : A
    {
        public B(int field)
        {
            _field = field;
        }

        public int GetField() { return _field; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var b = new B(n);
            Console.WriteLine(b.GetField());
        }
    }
}