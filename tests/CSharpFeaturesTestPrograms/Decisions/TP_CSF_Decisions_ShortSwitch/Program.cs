using System;

namespace TP_CSF_Decisions_ShortSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = short.Parse(Console.ReadLine());

            switch(s)
            {
                case 0:
                    Console.WriteLine(0);
                    break;
                case 1:
                    Console.WriteLine(1);
                    break;
                case 2:
                    Console.WriteLine(2);
                    break;
                case 3:
                    Console.WriteLine(3);
                    break;
                case 4:
                    Console.WriteLine(4);
                    break;
                case 5:
                    Console.WriteLine(5);
                    break;
                case 6:
                    Console.WriteLine(6);
                    break;
                case 7:
                    Console.WriteLine(7);
                    break;
                case 8:
                    Console.WriteLine(8);
                    break;
                case 9:
                    Console.WriteLine(9);
                    break;
                default:
                    Console.WriteLine("NO");
                    break;
            }
        }
    }
}