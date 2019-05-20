using System;
using System.Collections;

namespace TP_CSF_Inheritance_ExistingClassInheritance2
{
    public class StackA : Stack { }

    public class StackB : StackA { }

    public class StackC : StackB { }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var st = new StackC();

            for (int i = 0; i < n; i++) st.Push(int.Parse(Console.ReadLine()));

            for (int i = 0; i < n; i++) Console.WriteLine(st.Pop());
        }
    }
}