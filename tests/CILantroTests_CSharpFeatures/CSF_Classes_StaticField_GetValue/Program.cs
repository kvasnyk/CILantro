using System;

namespace CSF_Classes_StaticField_GetValue
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
            Console.WriteLine(Test._fieldSbyte);
            Console.WriteLine(Test._fieldShort);
            Console.WriteLine(Test._fieldInt);
            Console.WriteLine(Test._fieldLong);
            Console.WriteLine(Test._fieldByte);
            Console.WriteLine(Test._fieldUshort);
            Console.WriteLine(Test._fieldUint);
            Console.WriteLine(Test._fieldUlong);
            Console.WriteLine(Test._fieldChar);
            Console.WriteLine(Test._fieldFloat);
            Console.WriteLine(Test._fieldDouble);
            Console.WriteLine(Test._fieldDecimal);
            Console.WriteLine(Test._fieldString);
        }
    }
}