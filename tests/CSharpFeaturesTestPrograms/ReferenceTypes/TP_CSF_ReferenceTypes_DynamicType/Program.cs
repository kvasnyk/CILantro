using System;

namespace TP_CSF_ReferenceTypes_DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic d;

            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();

            d = n;
            Console.WriteLine(d);

            d = s;
            Console.WriteLine(d);

            d = new {
                n,
                s
            };
            Console.WriteLine(d.n);
            Console.WriteLine(d.s);
        }
    }
}