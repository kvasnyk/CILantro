﻿using System;

namespace CSF_DecisionMaking_IfTrue
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = bool.Parse(Console.ReadLine());

            if (b)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}