using System;

namespace CSF_Classes_StaticMethod_1Args
{
    public class Test
    {
        public static void WriteInt(int @int)
        {
            Console.WriteLine(@int);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var @int = int.Parse(Console.ReadLine());
            Test.WriteInt(@int);
        }
    }
}