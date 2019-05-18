using System;

namespace CSF_Classes_StaticMethod_2Args
{
    public class Test
    {
        public static void WriteSum(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            var a = int.Parse(line[0]);
            var b = int.Parse(line[1]);

            Test.WriteSum(a, b);
        }
    }
}