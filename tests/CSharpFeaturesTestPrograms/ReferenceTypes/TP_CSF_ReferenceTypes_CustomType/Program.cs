using System;

namespace TP_CSF_ReferenceTypes_CustomType
{
    public class Test
    {
        public int _n;

        public Test(int n)
        {
            _n = n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var test = new Test(n);
            Console.WriteLine(test._n);
        }
    }
}