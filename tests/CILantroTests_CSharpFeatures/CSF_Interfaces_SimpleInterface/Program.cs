using System;

namespace CSF_Interfaces_SimpleInterface
{
    public interface ITest
    {
    }

    public class TestA : ITest
    {
    }

    public class TestB : ITest
    {
    }

    public class TestC : ITest
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new TestA();
            var b = new TestB();
            var c = new TestC();
            Console.WriteLine("It works!");
        }
    }
}