using System;

namespace TP_CSF_Classes_PublicFields
{
    class TestClass
    {
        public string _stringField;

        public int _intField;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var testClass = new TestClass();
            testClass._stringField = Console.ReadLine();
            testClass._intField = int.Parse(Console.ReadLine());

            Console.WriteLine(testClass._stringField);
            Console.WriteLine(testClass._intField);
        }
    }
}