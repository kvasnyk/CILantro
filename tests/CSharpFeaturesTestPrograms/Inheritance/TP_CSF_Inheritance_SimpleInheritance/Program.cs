using System;

namespace TP_CSF_Inheritance_SimpleInheritance
{
    public class A
    {
    }

    public class B : A
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();

            Console.WriteLine("It works!");
        }
    }
}