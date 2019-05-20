using System;

namespace TP_CSF_Classes_InitFields
{
    public class InitFieldsTestClass
    {
        private string _s = "test";

        private int _n = 4;

        public string GetStringValue()
        {
            return _s;
        }

        public int GetIntValue()
        {
            return _n;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var instance = new InitFieldsTestClass();
            Console.WriteLine(instance.GetStringValue());
            Console.WriteLine(instance.GetIntValue());
        }
    }
}