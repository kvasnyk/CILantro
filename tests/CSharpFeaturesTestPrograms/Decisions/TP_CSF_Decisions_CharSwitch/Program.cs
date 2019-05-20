using System;

namespace TP_CSF_Decisions_CharSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = char.Parse(Console.ReadLine());

            switch(c)
            {
                case 'A':
                case 'a':
                    Console.WriteLine("A");
                    break;
                case 'B':
                case 'b':
                    Console.WriteLine("B");
                    break;
                case 'C':
                case 'c':
                    Console.WriteLine("C");
                    break;
                case 'D':
                case 'd':
                    Console.WriteLine("D");
                    break;
                case 'E':
                case 'e':
                    Console.WriteLine("E");
                    break;
                case 'F':
                case 'f':
                    Console.WriteLine("F");
                    break;
                case 'G':
                case 'g':
                    Console.WriteLine("G");
                    break;
                case 'H':
                case 'h':
                    Console.WriteLine("H");
                    break;
                case 'I':
                case 'i':
                    Console.WriteLine("I");
                    break;
                case 'J':
                case 'j':
                    Console.WriteLine("J");
                    break;
                case 'K':
                case 'k':
                    Console.WriteLine("K");
                    break;
                case 'L':
                case 'l':
                    Console.WriteLine("L");
                    break;
                case 'M':
                case 'm':
                    Console.WriteLine("M");
                    break;
                case 'N':
                case 'n':
                    Console.WriteLine("N");
                    break;
                case 'O':
                case 'o':
                    Console.WriteLine("O");
                    break;
                case 'P':
                case 'p':
                    Console.WriteLine("P");
                    break;
                case 'Q':
                case 'q':
                    Console.WriteLine("Q");
                    break;
                case 'R':
                case 'r':
                    Console.WriteLine("R");
                    break;
                case 'S':
                case 's':
                    Console.WriteLine("S");
                    break;
                case 'T':
                case 't':
                    Console.WriteLine("T");
                    break;
                case 'U':
                case 'u':
                    Console.WriteLine("U");
                    break;
                case 'V':
                case 'v':
                    Console.WriteLine("V");
                    break;
                case 'W':
                case 'w':
                    Console.WriteLine("W");
                    break;
                case 'X':
                case 'x':
                    Console.WriteLine("X");
                    break;
                case 'Y':
                case 'y':
                    Console.WriteLine("Y");
                    break;
                case 'Z':
                case 'z':
                    Console.WriteLine("Z");
                    break;
                default:
                    Console.WriteLine("non-letter");
                    break;
            }
        }
    }
}