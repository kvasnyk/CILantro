using System;

namespace CSF_Classes_StaticMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteSomething((char)0, 0);
        }

        static void WriteSomething(char c, long l)
        {
            Console.WriteLine(c);
            Console.WriteLine(l);
        }
    }
}