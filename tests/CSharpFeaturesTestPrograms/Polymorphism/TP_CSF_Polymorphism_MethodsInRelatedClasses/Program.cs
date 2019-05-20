using System;

namespace TP_CSF_Polymorphism_MethodsInRelatedClasses
{
    public class TestA
    {
        private int _n1;

        public void Save(int n1) { _n1 = n1; }

        public int Get1() { return _n1; }
    }

    public class TestB : TestA
    {
        private int _n2;

        public void Save(int n1, int n2) { Save(n1); _n2 = n2; }

        public int Get2() { return _n2; }
    }

    public class TestC : TestB
    {
        private int _n3;

        public void Save(int n1, int n2, int n3) { Save(n1, n2); _n3 = n3; }

        public int Get3() { return _n3; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if(n == 1)
            {
                var test = new TestA();
                var x1 = int.Parse(Console.ReadLine());
                test.Save(x1);

                Console.WriteLine(test.Get1());
            }
            else if(n == 2)
            {
                var test = new TestB();
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                test.Save(x1, x2);

                Console.WriteLine(test.Get1());
                Console.WriteLine(test.Get2());
            }
            else
            {
                var test = new TestC();
                var x1 = int.Parse(Console.ReadLine());
                var x2 = int.Parse(Console.ReadLine());
                var x3 = int.Parse(Console.ReadLine());
                test.Save(x1, x2, x3);

                Console.WriteLine(test.Get1());
                Console.WriteLine(test.Get2());
                Console.WriteLine(test.Get3());
            }
        }
    }
}