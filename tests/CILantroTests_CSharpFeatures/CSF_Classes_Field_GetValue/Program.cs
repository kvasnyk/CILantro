using System;

namespace CSF_Classes_Field_GetValue
{
    public class Test
    {
        public sbyte _fieldSbyte = -4;

        public short _fieldShort = -12;

        public int _fieldInt = -1023;

        public long _fieldLong = -10432432423;

        public byte _fieldByte = 4;

        public ushort _fieldUshort = 12;

        public uint _fieldUint = 1023;

        public ulong _fieldUlong = 10432432423;

        public char _fieldChar = 'g';

        public float _fieldFloat = 3.14f;

        public double _fieldDouble = 3.15;

        public decimal _fieldDecimal = 3.17m;

        public string _fieldString = "hello!";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();

            Console.WriteLine(test._fieldSbyte);
            Console.WriteLine(test._fieldShort);
            Console.WriteLine(test._fieldInt);
            Console.WriteLine(test._fieldLong);
            Console.WriteLine(test._fieldByte);
            Console.WriteLine(test._fieldUshort);
            Console.WriteLine(test._fieldUint);
            Console.WriteLine(test._fieldUlong);
            Console.WriteLine(test._fieldChar);
            Console.WriteLine(test._fieldFloat);
            Console.WriteLine(test._fieldDouble);
            Console.WriteLine(test._fieldDecimal);
            Console.WriteLine(test._fieldString);
        }
    }
}