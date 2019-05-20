using System;

namespace StringApplication
{

    class StringProg
    {

        static void Main(string[] args)
        {
            string str = "This is test";

            if (str.Contains("test"))
            {
                Console.WriteLine("The sequence 'test' was found.");
            }
        }
    }
}