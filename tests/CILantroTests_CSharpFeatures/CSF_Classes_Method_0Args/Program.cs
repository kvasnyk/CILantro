using System;

namespace CSF_Classes_Method_0Args
{
    public class Test
    {
        private int _n;

        public Test(int n)
        {
            _n = n;
        }

        public int GetSquare()
        {
            return _n * _n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var test = new Test(n);
            Console.WriteLine(test.GetSquare());
        }
    }
}