using System;

namespace TP_CSF_Methods_PrivateMethod
{
    public class PrivateMethodTestClass
    {
        public int _n;

        public PrivateMethodTestClass(int n)
        {
            SetField(n);
        }

        private void SetField(int n)
        {
            _n = n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var instance = new PrivateMethodTestClass(n);
            Console.WriteLine(instance._n);
        }
    }
}