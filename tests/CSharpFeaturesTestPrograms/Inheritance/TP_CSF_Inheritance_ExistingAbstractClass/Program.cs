using System;

namespace TP_CSF_Inheritance_ExistingAbstractClass
{
    public class StringComparerA : StringComparer
    {
        public override int Compare(string x, string y)
        {
            return 1;
        }

        public override bool Equals(string x, string y)
        {
            return true;
        }

        public override int GetHashCode(string obj)
        {
            return 1;
        }
    }

    public class StringComparerB : StringComparerA { }

    public class StringComparerC : StringComparerB { }

    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            var comparer = new StringComparerC();

            Console.WriteLine(comparer.Compare(s, t));
        }
    }
}