using System;

namespace OperatorsAppl
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 21;
            int b = 10;
            int c;

            c = a + b;
            Console.WriteLine("Line 1 - Value of c is {0}", c);

            c = a - b;
            Console.WriteLine("Line 2 - Value of c is {0}", c);

            c = a * b;
            Console.WriteLine("Line 3 - Value of c is {0}", c);

            c = a / b;
            Console.WriteLine("Line 4 - Value of c is {0}", c);

            c = a % b;
            Console.WriteLine("Line 5 - Value of c is {0}", c);

            c = a++;
            Console.WriteLine("Line 6 - Value of c is {0}", c);

            c = a--;
            Console.WriteLine("Line 7 - Value of c is {0}", c);
        }
    }
}