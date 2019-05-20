using System;

namespace TP_CSF_Methods_PrivateStaticMethod
{
    public class PrivateStaticMethodTestClass
    {
        private int _result;

        public PrivateStaticMethodTestClass(int a, int b)
        {
            _result = Add(a, b);
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }

        public int GetResult()
        {
            return _result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var instance = new PrivateStaticMethodTestClass(a, b);
            Console.WriteLine(instance.GetResult());
        }
    }
}