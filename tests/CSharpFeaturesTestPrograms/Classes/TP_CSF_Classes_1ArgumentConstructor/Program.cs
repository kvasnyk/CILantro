using System;

namespace TP_CSF_Classes_1ArgumentConstructor
{
    class OneArgumentConstructorClass
    {
        public int _field;

        public OneArgumentConstructorClass(int field)
        {
            _field = field;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var instance = new OneArgumentConstructorClass(n);
            Console.WriteLine(instance._field);
        }
    }
}