using System;

namespace StringApplication
{

    class StringProg
    {

        static void Main(string[] args)
        {
            string[] starray = new string[]{"Down the way nights are dark",
            "And the sun shines daily on the mountain top",
            "I took a trip on a sailing ship",
            "And when I reached Jamaica",
            "I made a stop"};

            string str = String.Join("\n", starray);
            Console.WriteLine(str);
        }
    }
}