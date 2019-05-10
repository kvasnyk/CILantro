using System;

namespace BrakeStatementAppl
{
    class Program
    {
        static void Main(string[] args)
        {
            /* local variable definition */
            int a = 10;

            /* while loop execution */
            while (a < 20)
            {
                Console.WriteLine("value of a: {0}", a);
                a++;

                if (a > 15)
                {
                    /* terminate the loop using break statement */
                    break;
                }
            }
        }
    }
}