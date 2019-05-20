using System;

namespace TP_CSF_Classes_ManyConstructors
{
    public class ManyConstructorsClass
    {
        public int _field1;

        public int _field2;

        public int _field3;

        public ManyConstructorsClass(int field1)
        {
            _field1 = field1;
        }

        public ManyConstructorsClass(int field1, int field2)
        {
            _field1 = field1;
            _field2 = field2;
        }

        public ManyConstructorsClass(int field1, int field2, int field3)
        {
            _field1 = field1;
            _field2 = field2;
            _field3 = field3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            if(n == 1)
            {
                var f1 = int.Parse(Console.ReadLine());
                var instance = new ManyConstructorsClass(f1);
                Console.WriteLine(instance._field1);
            }
            else if(n == 2)
            {
                var f1 = int.Parse(Console.ReadLine());
                var f2 = int.Parse(Console.ReadLine());
                var instance = new ManyConstructorsClass(f1, f2);
                Console.WriteLine(instance._field1);
                Console.WriteLine(instance._field2);
            }
            else
            {
                var f1 = int.Parse(Console.ReadLine());
                var f2 = int.Parse(Console.ReadLine());
                var f3 = int.Parse(Console.ReadLine());
                var instance = new ManyConstructorsClass(f1, f2, f3);
                Console.WriteLine(instance._field1);
                Console.WriteLine(instance._field2);
                Console.WriteLine(instance._field3);
            }
        }
    }
}