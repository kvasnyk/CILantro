using System;
using System.Text;

namespace TP_CSF_ReferenceTypes_ExistingType
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = Console.ReadLine();
            var s2 = Console.ReadLine();

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(s1);
            stringBuilder.Append(s2);

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}