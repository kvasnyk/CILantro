using System;

namespace TP_CSF_Classes_Destructor
{
    public class DestructorTestClass
    {
        private int _field;

        public DestructorTestClass(int field)
        {
            _field = field;
        }

        ~DestructorTestClass()
        {
            Console.WriteLine(_field);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var instance = new DestructorTestClass(n);
        }
    }
}