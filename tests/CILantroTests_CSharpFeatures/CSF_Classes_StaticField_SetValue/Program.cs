using System;

namespace CSF_Classes_StaticField_SetValue
{
    public class Test
    {
        public static sbyte _fieldSbyte = -4;

        public static short _fieldShort = -12;

        public static int _fieldInt = -1023;

        public static long _fieldLong = -10432432423;

        public static byte _fieldByte = 4;

        public static ushort _fieldUshort = 12;

        public static uint _fieldUint = 1023;

        public static ulong _fieldUlong = 10432432423;

        public static char _fieldChar = 'g';

        public static float _fieldFloat = 3.14f;

        public static double _fieldDouble = 3.15;

        public static decimal _fieldDecimal = 3.17m;

        public static string _fieldString = "hello!";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var @sbyte = sbyte.Parse(Console.ReadLine());
            Test._fieldSbyte += @sbyte;
            Console.WriteLine(Test._fieldSbyte);

            var @short = short.Parse(Console.ReadLine());
            Test._fieldShort += @short;
            Console.WriteLine(Test._fieldShort);

            var @int = int.Parse(Console.ReadLine());
            Test._fieldInt += @int;
            Console.WriteLine(Test._fieldInt);

            var @long = long.Parse(Console.ReadLine());
            Test._fieldLong += @long;
            Console.WriteLine(Test._fieldLong);

            var @byte = byte.Parse(Console.ReadLine());
            Test._fieldByte += @byte;
            Console.WriteLine(Test._fieldByte);

            var @ushort = ushort.Parse(Console.ReadLine());
            Test._fieldUshort += @ushort;
            Console.WriteLine(Test._fieldUshort);

            var @uint = uint.Parse(Console.ReadLine());
            Test._fieldUint += @uint;
            Console.WriteLine(Test._fieldUint);

            var @ulong = ulong.Parse(Console.ReadLine());
            Test._fieldUlong += @ulong;
            Console.WriteLine(Test._fieldUlong);

            var @char = char.Parse(Console.ReadLine());
            Test._fieldChar += @char;
            Console.WriteLine(Test._fieldChar);

            var @float = float.Parse(Console.ReadLine());
            Test._fieldFloat += @float;
            Console.WriteLine(Test._fieldFloat);

            var @double = double.Parse(Console.ReadLine());
            Test._fieldDouble += @double;
            Console.WriteLine(Test._fieldDouble);

            var @decimal = decimal.Parse(Console.ReadLine());
            Test._fieldDecimal += @decimal;
            Console.WriteLine(Test._fieldDecimal);

            var @string = Console.ReadLine();
            Test._fieldString += @string;
            Console.WriteLine(Test._fieldString);
        }
    }
}
