using System;

namespace TP_CSF_Methods_PublicMethod
{
    public class PublicMethodTestClass
    {
        public int _field;

        public void SetField(int n)
        {
            _field = n;
        }

        public int GetField()
        {
            return _field;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var instance = new PublicMethodTestClass();
            instance.SetField(n);
            Console.WriteLine(instance.GetField());
        }
    }
}
