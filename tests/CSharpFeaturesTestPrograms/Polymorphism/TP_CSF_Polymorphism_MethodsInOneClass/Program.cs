using System;

namespace TP_CSF_Polymorphism_MethodsInOneClass
{
    public class TestClass
    {
        private int _n1;

        private int _n2;

        private int _n3;

        public void Save(int n1)
        {
            _n1 = n1;
        }

        public void Save(int n1, int n2)
        {
            Save(n1);
            _n2 = n2;
        }

        public void Save(int n1, int n2, int n3)
        {
            Save(n1, n2);
            _n3 = n3;
        }

        public int Get1() { return _n1; }

        public int Get2() { return _n2; }

        public int Get3() { return _n3; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var instance = new TestClass();

            if(n == 1)
            {
                var x1 = int.Parse(Console.ReadLine());
                instance.Save(x1);
            }
            else if(n == 2)
            {
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                instance.Save(x1, x2);
            }
            else
            {
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                var x3 = int.Parse(Console.ReadLine());
                instance.Save(x1, x2, x3);
            }

            Console.WriteLine(instance.Get1());
            if (n > 1) Console.WriteLine(instance.Get2());
            if (n > 2) Console.WriteLine(instance.Get3());
        }
    }
}