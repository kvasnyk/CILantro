using System;

namespace TP_CSF_Classes_PrivateStaticFields
{
    public class PrivateStaticFieldsTestClass
    {
        private static int _counter;

        public PrivateStaticFieldsTestClass()
        {
            _counter++;
        }

        public int GetCounter()
        {
            return _counter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                var instance = new PrivateStaticFieldsTestClass();
                if (i == n - 1) Console.WriteLine(instance.GetCounter());
            }
        }
    }
}