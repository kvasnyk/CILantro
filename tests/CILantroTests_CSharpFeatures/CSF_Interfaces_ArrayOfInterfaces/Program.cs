using System;

namespace CSF_Interfaces_ArrayOfInterfaces
{
    public interface ITest
    {
        void Write(int n);
    }

    public class TestA : ITest
    {
        public void Write(int n)
        {
            Console.WriteLine(n);
        }
    }

    public class TestB : ITest
    {
        public void Write(int n)
        {
            Console.WriteLine(n + 1);
        }
    }

    public class TestC : ITest
    {
        public void Write(int n)
        {
            Console.WriteLine(n + 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var a = new TestA();
            var b = new TestB();
            var c = new TestC();

            var arr = new ITest[3] { a, b, c };

            foreach (var test in arr)
                test.Write(n);
        }
    }
}