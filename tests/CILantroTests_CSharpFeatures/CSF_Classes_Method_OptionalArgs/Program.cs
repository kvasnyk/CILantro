using System;

namespace CSF_Classes_Method_OptionalArgs
{
    public class Test
    {
        public void Write(int a = 1, int b = 2, int c = 3)
        {
            Console.WriteLine(a + b + c);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            var test = new Test();
            test.Write();
            test.Write(a);
            test.Write(a, b);
            test.Write(a, b, c);
        }
    }
}