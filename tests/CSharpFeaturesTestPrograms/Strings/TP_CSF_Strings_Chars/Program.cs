﻿using System;

namespace TP_CSF_Strings_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());

            var character = s[n];

            Console.WriteLine(character);
        }
    }
}