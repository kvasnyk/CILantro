using System;

namespace CSF_Interfaces_ExternalInterface
{
    public class Test : ICloneable
    {
        public int _a;

        public Test(int a)
        {
            _a = a;
        }

        public object Clone()
        {
            return new Test(_a);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());

            var t1 = new Test(a);
            var t2 = t1.Clone() as Test;
            var t3 = t2.Clone() as Test;

            Console.WriteLine(t1._a);
            Console.WriteLine(t2._a);
            Console.WriteLine(t3._a);
        }
    }
}