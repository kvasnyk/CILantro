using System;
using System.Collections;

namespace TP_CSF_Inheritance_ExistingClassInheritance
{
    public class NewList : ArrayList
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var list = new NewList();
            for(int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                list.Add(x);
            }

            for (int i = 0; i < n; i++) Console.WriteLine(list[i]);
        }
    }
}