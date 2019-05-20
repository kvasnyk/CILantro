using System;

namespace TP_CSF_Decisions_BoolSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = bool.Parse(Console.ReadLine());

            switch(b)
            {
                case true:
                    Console.WriteLine("YES");
                    break;
                case false:
                    Console.WriteLine("NO");
                    break;
            }
        }
    }
}