using System;

namespace CSF_Inheritance_SimpleInheritance
{
    public class A
    {
        public virtual void Write()
        {
            Console.WriteLine("A");
        }
    }

    public class B : A
    {
        public override void Write()
        {
            Console.WriteLine("B");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();

            a.Write();
            b.Write();
        }
    }
}