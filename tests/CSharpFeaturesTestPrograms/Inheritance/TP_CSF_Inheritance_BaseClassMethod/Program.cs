using System;

namespace TP_CSF_Inheritance_BaseClassMethod
{
    public class A
    {
        public int GetValueA()
        {
            return 1;
        }
    }

    public class B : A
    {
        public int GetValueB()
        {
            return 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();

            Console.WriteLine(a.GetValueA());
            Console.WriteLine(b.GetValueA());
            Console.WriteLine(b.GetValueB());
        }
    }
}