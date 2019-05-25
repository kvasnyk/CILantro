using System;

namespace CSF_Interfaces_OneMethod
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

            ITest a = new TestA();
            ITest b = new TestB();
            ITest c = new TestC();

            a.Write(n);
            b.Write(n);
            c.Write(n);
        }
    }
}