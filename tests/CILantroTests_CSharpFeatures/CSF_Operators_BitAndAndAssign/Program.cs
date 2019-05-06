using System;

namespace CSF_Operators_BitAndAndAssign
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = sbyte.Parse(Console.ReadLine());
            var b = short.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = long.Parse(Console.ReadLine());
            var e = byte.Parse(Console.ReadLine());
            var f = ushort.Parse(Console.ReadLine());
            var g = uint.Parse(Console.ReadLine());
            var h = ulong.Parse(Console.ReadLine());
            var i = char.Parse(Console.ReadLine());
            var j = float.Parse(Console.ReadLine());
            var k = double.Parse(Console.ReadLine());
            var l = decimal.Parse(Console.ReadLine());

            // a

            var aa = a;

            Console.Write(aa);
            Console.Write(" ");
            aa &= a;
            Console.Write(aa);
            Console.Write(" ");
            Console.WriteLine();

            // b

            var bb = b;

            Console.Write(bb);
            Console.Write(" ");
            bb &= a;
            Console.Write(bb);
            Console.Write(" ");
            bb &= b;
            Console.Write(bb);
            Console.Write(" ");
            bb &= e;
            Console.Write(bb);
            Console.Write(" ");
            Console.WriteLine();

            // c

            var cc = c;

            Console.Write(cc);
            Console.Write(" ");
            cc &= a;
            Console.Write(cc);
            Console.Write(" ");
            cc &= b;
            Console.Write(cc);
            Console.Write(" ");
            cc &= c;
            Console.Write(cc);
            Console.Write(" ");
            cc &= e;
            Console.Write(cc);
            Console.Write(" ");
            cc &= f;
            Console.Write(cc);
            Console.Write(" ");
            cc &= i;
            Console.Write(cc);
            Console.Write(" ");
            Console.WriteLine();

            // d

            var dd = d;

            Console.Write(dd);
            Console.Write(" ");
            dd &= a;
            Console.Write(dd);
            Console.Write(" ");
            dd &= b;
            Console.Write(dd);
            Console.Write(" ");
            dd &= c;
            Console.Write(dd);
            Console.Write(" ");
            dd &= d;
            Console.Write(dd);
            Console.Write(" ");
            dd &= e;
            Console.Write(dd);
            Console.Write(" ");
            dd &= f;
            Console.Write(dd);
            Console.Write(" ");
            dd &= g;
            Console.Write(dd);
            Console.Write(" ");
            dd &= i;
            Console.Write(dd);
            Console.Write(" ");
            Console.WriteLine();

            // e

            var ee = e;

            Console.Write(ee);
            Console.Write(" ");
            ee &= e;
            Console.Write(ee);
            Console.Write(" ");
            Console.WriteLine();

            // f

            var ff = f;

            Console.Write(ff);
            Console.Write(" ");
            ff &= e;
            Console.Write(ff);
            Console.Write(" ");
            ff &= f;
            Console.Write(ff);
            Console.Write(" ");
            ff &= i;
            Console.Write(ff);
            Console.Write(" ");
            Console.WriteLine();

            // g

            var gg = g;

            Console.Write(gg);
            Console.Write(" ");
            gg &= e;
            Console.Write(gg);
            Console.Write(" ");
            gg &= f;
            Console.Write(gg);
            Console.Write(" ");
            gg &= g;
            Console.Write(gg);
            Console.Write(" ");
            gg &= i;
            Console.Write(gg);
            Console.Write(" ");
            Console.WriteLine();

            // h

            var hh = h;

            Console.Write(hh);
            Console.Write(" ");
            hh &= e;
            Console.Write(hh);
            Console.Write(" ");
            hh &= f;
            Console.Write(hh);
            Console.Write(" ");
            hh &= g;
            Console.Write(hh);
            Console.Write(" ");
            hh &= h;
            Console.Write(hh);
            Console.Write(" ");
            hh &= i;
            Console.Write(hh);
            Console.Write(" ");
            Console.WriteLine();

            // i

            var ii = i;

            Console.Write(ii);
            Console.Write(" ");
            ii &= i;
            Console.Write(ii);
            Console.Write(" ");
            Console.WriteLine();
        }
    }
}