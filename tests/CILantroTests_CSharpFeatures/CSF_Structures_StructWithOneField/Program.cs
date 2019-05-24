using System;

namespace CSF_Structures_StructWithOneField
{
    public struct Test
    {
        public int Field;

        public Test(int field)
        {
            Field = field;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var @int = int.Parse(Console.ReadLine());
            var test = new Test();
            var test2 = new Test(@int);
            Console.WriteLine(test.Field);
            Console.WriteLine(test2.Field);
        }
    }
}