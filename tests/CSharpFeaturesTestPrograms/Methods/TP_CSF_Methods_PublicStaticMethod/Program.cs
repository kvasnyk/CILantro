using System;

namespace TP_CSF_Methods_PublicStaticMethod
{
    public class PublicStaticMethodTestClass
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.WriteLine(PublicStaticMethodTestClass.Add(a, b));
        }
    }
}