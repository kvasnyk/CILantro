using System;

namespace TP_CSF_Decisions_StringSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            switch(s)
            {
                case "NORTH":
                    Console.WriteLine("N");
                    break;
                case "SOUTH":
                    Console.WriteLine("S");
                    break;
                case "EAST":
                    Console.WriteLine("E");
                    break;
                case "WEST":
                    Console.WriteLine("W");
                    break;
                default:
                    Console.WriteLine("---");
                    break;
            }
        }
    }
}