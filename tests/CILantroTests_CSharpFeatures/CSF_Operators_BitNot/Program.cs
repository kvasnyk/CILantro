using System;

namespace CSF_Operator_BitNot
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

            Console.WriteLine(~a);
            Console.WriteLine(~b);
            Console.WriteLine(~c);
            Console.WriteLine(~d);
            Console.WriteLine(~e);
            Console.WriteLine(~f);
            Console.WriteLine(~g);
            Console.WriteLine(~h);
            Console.WriteLine(~i);
        }
    }
}