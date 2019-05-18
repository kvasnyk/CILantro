using System;

namespace CSF_Classes_StaticMethod_3Args
{
    public class Test
    {
        public static void WriteSum(int a, int b, int c)
        {
            Console.WriteLine(a + b + c);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            var a = int.Parse(line[0]);
            var b = int.Parse(line[1]);
            var c = int.Parse(line[2]);

            Test.WriteSum(a, b, c);
        }
    }
}