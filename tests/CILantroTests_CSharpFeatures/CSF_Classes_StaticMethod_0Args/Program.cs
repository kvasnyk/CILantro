using System;

namespace CSF_Classes_StaticMethod_0Args
{
    public class Test
    {
        public static void WriteSomething()
        {
            Console.WriteLine("something");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test.WriteSomething();
        }
    }
}