using System;

namespace CSF_Classes_Constructor_1Args
{
    public class Test
    {
        public int _n = -3;

        public Test(int n)
        {
            _n += n;
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