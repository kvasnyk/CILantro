
using System;

namespace CSF_DecisionMaking_IfNotEqualZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split(' ');
            var a = sbyte.Parse(line1[0]);

            var line2 = Console.ReadLine().Split(' ');
            var b = short.Parse(line2[0]);

            var line3 = Console.ReadLine().Split(' ');
            var c = int.Parse(line3[0]);

            var line4 = Console.ReadLine().Split(' ');
            var d = long.Parse(line4[0]);

            var line5 = Console.ReadLine().Split(' ');
            var e = byte.Parse(line5[0]);

            var line6 = Console.ReadLine().Split(' ');
            var f = ushort.Parse(line6[0]);

            var line7 = Console.ReadLine().Split(' ');
            var g = uint.Parse(line7[0]);

            var line8 = Console.ReadLine().Split(' ');
            var h = ulong.Parse(line8[0]);

            var line9 = Console.ReadLine().Split(' ');
            var i = char.Parse(line9[0]);

            var line10 = Console.ReadLine().Split(' ');
            var j = float.Parse(line10[0]);

            var line11 = Console.ReadLine().Split(' ');
            var k = double.Parse(line11[0]);

            var line12 = Console.ReadLine().Split(' ');
            var l = decimal.Parse(line12[0]);

            if (a != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (b != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (c != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (d != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (e != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (f != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (g != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (h != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (i != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (j != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (k != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            if (l != 0) Console.WriteLine("Y"); else Console.WriteLine("N");
            Console.WriteLine();
        }
    }
}