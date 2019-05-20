using System;

namespace TP_CSF_Classes_NoArgumentsConstructor
{
    class NoArgumentsConstructorClass
    {
        public int _int;

        public string _string;

        public NoArgumentsConstructorClass()
        {
            _int = 4;
            _string = "It's four!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var instance = new NoArgumentsConstructorClass();
            Console.WriteLine(instance._int);
            Console.WriteLine(instance._string);
        }
    }
}