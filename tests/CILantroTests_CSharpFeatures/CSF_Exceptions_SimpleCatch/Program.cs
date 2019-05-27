using System;

namespace CSF_Exceptions_SimpleCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var y = 2 - 2;
                var x = 1 / y;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught!");
            }
        }
    }
}