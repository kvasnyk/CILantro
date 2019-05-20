using System;

namespace TP_CSF_Classes_PrivateFields
{
    public class PrivateFieldsTestClass
    {
        private string _stringField;

        public void SetField(string s)
        {
            _stringField = s;
        }

        public string GetField()
        {
            return _stringField;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var instance = new PrivateFieldsTestClass();
            instance.SetField(s);
            Console.WriteLine(instance.GetField());
        }
    }
}