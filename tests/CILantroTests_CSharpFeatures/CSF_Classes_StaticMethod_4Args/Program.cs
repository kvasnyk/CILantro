using System;

namespace CSF_Classes_StaticMethod_4Args
{
    public class Test
    {
        public static void WriteSum(int a, int b, int c, int d)
        {
            Console.WriteLine(a + b + c + d);
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
            var d = int.Parse(line[3]);

            Test.WriteSum(a, b, c, d);
        }
    }
}