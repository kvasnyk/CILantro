using System;

namespace CSF_Classes_StaticField_SetValue
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

            var @sbyte = sbyte.Parse(Console.ReadLine());
            test._fieldSbyte += @sbyte;
            Console.WriteLine(test._fieldSbyte);

            var @short = short.Parse(Console.ReadLine());
            test._fieldShort += @short;
            Console.WriteLine(test._fieldShort);

            var @int = int.Parse(Console.ReadLine());
            test._fieldInt += @int;
            Console.WriteLine(test._fieldInt);

            var @long = long.Parse(Console.ReadLine());
            test._fieldLong += @long;
            Console.WriteLine(test._fieldLong);

            var @byte = byte.Parse(Console.ReadLine());
            test._fieldByte += @byte;
            Console.WriteLine(test._fieldByte);

            var @ushort = ushort.Parse(Console.ReadLine());
            test._fieldUshort += @ushort;
            Console.WriteLine(test._fieldUshort);

            var @uint = uint.Parse(Console.ReadLine());
            test._fieldUint += @uint;
            Console.WriteLine(test._fieldUint);

            var @ulong = ulong.Parse(Console.ReadLine());
            test._fieldUlong += @ulong;
            Console.WriteLine(test._fieldUlong);

            var @char = char.Parse(Console.ReadLine());
            test._fieldChar += @char;
            Console.WriteLine(test._fieldChar);

            var @float = float.Parse(Console.ReadLine());
            test._fieldFloat += @float;
            Console.WriteLine(test._fieldFloat);

            var @double = double.Parse(Console.ReadLine());
            test._fieldDouble += @double;
            Console.WriteLine(test._fieldDouble);

            var @decimal = decimal.Parse(Console.ReadLine());
            test._fieldDecimal += @decimal;
            Console.WriteLine(test._fieldDecimal);

            var @string = Console.ReadLine();
            test._fieldString += @string;
            Console.WriteLine(test._fieldString);
        }
    }
}
