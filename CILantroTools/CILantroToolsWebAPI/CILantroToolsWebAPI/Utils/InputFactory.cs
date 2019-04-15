using CILantroToolsWebAPI.Models.Tests.InputOutput;
using CILantroToolsWebAPI.Models.Tests.InputOutput.Elements;
using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CILantroToolsWebAPI.Utils
{
    public class InputFactory
    {
        private readonly InputOutput _input;

        private readonly Random _random;

        public InputFactory(InputOutput input)
        {
            _input = input;
            _random = new Random(Guid.NewGuid().GetHashCode());
        }

        public string GenerateRandomInput()
        {
            if (_input.IsEmpty)
                return string.Empty;

            var builder = new StringBuilder();

            foreach (var inputLine in _input.Lines)
            {
                foreach (var inputElement in inputLine.Elements)
                {
                    if (inputElement is BoolElement boolElement)
                    {
                        var @bool = GenerateBool(boolElement);
                        builder.Append(@bool.ToString());
                    }
                    else if (inputElement is StringElement stringElement)
                    {
                        var @string = GenerateString(stringElement);
                        builder.Append(@string.ToString());
                    }
                    else if (inputElement is ByteElement byteElement)
                    {
                        var @byte = GenerateByte(byteElement);
                        builder.Append(@byte.ToString());
                    }
                    else if (inputElement is IntElement intElement)
                    {
                        var @int = GenerateInt(intElement);
                        builder.Append(@int.ToString());
                    }
                    else if (inputElement is LongElement longElement)
                    {
                        var @long = GenerateLong(longElement);
                        builder.Append(@long.ToString());
                    }
                    else if (inputElement is SbyteElement sbyteElement)
                    {
                        var @sbyte = GenerateSbyte(sbyteElement);
                        builder.Append(@sbyte.ToString());
                    }
                    else if (inputElement is ShortElement shortElement)
                    {
                        var @short = GenerateShort(shortElement);
                        builder.Append(@short.ToString());
                    }
                    else if (inputElement is UintElement uintElement)
                    {
                        var @uint = GenerateUint(uintElement);
                        builder.Append(@uint.ToString());
                    }
                    else if (inputElement is UlongElement ulongElement)
                    {
                        var @ulong = GenerateUlong(ulongElement);
                        builder.Append(@ulong.ToString());
                    }
                    else if (inputElement is UshortElement ushortElement)
                    {
                        var @ushort = GenerateUshort(ushortElement);
                        builder.Append(@ushort.ToString());
                    }
                    else if (inputElement is FloatElement floatElement)
                    {
                        var @float = GenerateFloat(floatElement);
                        builder.Append(@float.ToString());
                    }
                    else if (inputElement is DoubleElement doubleElement)
                    {
                        var @double = GenerateDouble(doubleElement);
                        builder.Append(@double.ToString());
                    }
                    else if (inputElement is DecimalElement decimalElement)
                    {
                        var @decimal = GenerateDecimal(decimalElement);
                        builder.Append(@decimal.ToString());
                    }
                    else if (inputElement is CharElement charElement)
                    {
                        var @char = GenerateChar(charElement);
                        builder.Append(@char.ToString());
                    }
                    else
                    {
                        return null;
                    }

                    builder.Append(' ');
                }

                builder.Remove(builder.Length - 1, 1);
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private bool GenerateBool(BoolElement boolElement)
        {
            var randomInt = _random.Next(0, 2);
            return randomInt == 0;
        }

        private string GenerateString(StringElement stringElement)
        {
            var possibleChars = string.Empty;
            if (stringElement.HasBigLetters)
                possibleChars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (stringElement.HasSmallLetters)
                possibleChars += "abcdefghijklmnopqrstuvwxyz";
            if (stringElement.HasDigits)
                possibleChars += "0123456789";
            if (stringElement.HasSymbols)
                possibleChars += "!@#$%^&*()-_=+[]{}\\|;:'\"/?.>,<`~";

            var length = _random.Next(stringElement.MinLength, stringElement.MaxLength + 1);

            return new string(Enumerable.Repeat(0, length).Select(x => possibleChars[_random.Next(0, possibleChars.Length)]).ToArray());
        }

        private char GenerateChar(CharElement charElement)
        {
            var stringElement = new StringElement
            {
                Type = "String",
                Name = charElement.Name,
                MinLength = 1,
                MaxLength = 1,
                HasBigLetters = charElement.HasBigLetters,
                HasDigits = charElement.HasDigits,
                HasSmallLetters = charElement.HasSmallLetters,
                HasSymbols = charElement.HasSymbols
            };

            return GenerateString(stringElement)[0];
        }

        private byte GenerateByte(ByteElement byteElement)
        {
            var min = (BigInteger)byteElement.MinValue;
            var max = (BigInteger)byteElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += byteElement.MinValue;

            return (byte)b;
        }

        private int GenerateInt(IntElement intElement)
        {
            var min = (BigInteger)intElement.MinValue;
            var max = (BigInteger)intElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += intElement.MinValue;

            return (int)b;
        }

        private long GenerateLong(LongElement longElement)
        {
            var min = (BigInteger)longElement.MinValue;
            var max = (BigInteger)longElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += longElement.MinValue;

            return (long)b;
        }

        private sbyte GenerateSbyte(SbyteElement sbyteElement)
        {
            var min = (BigInteger)sbyteElement.MinValue;
            var max = (BigInteger)sbyteElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += sbyteElement.MinValue;

            return (sbyte)b;
        }

        private uint GenerateUint(UintElement uintElement)
        {
            var min = (BigInteger)uintElement.MinValue;
            var max = (BigInteger)uintElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += uintElement.MinValue;

            return (uint)b;
        }

        private ulong GenerateUlong(UlongElement ulongElement)
        {
            var min = (BigInteger)ulongElement.MinValue;
            var max = (BigInteger)ulongElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += ulongElement.MinValue;

            return (ulong)b;
        }

        private ushort GenerateUshort(UshortElement ushortElement)
        {
            var min = (BigInteger)ushortElement.MinValue;
            var max = (BigInteger)ushortElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += ushortElement.MinValue;

            return (ushort)b;
        }

        private short GenerateShort(ShortElement shortElement)
        {
            var min = (BigInteger)shortElement.MinValue;
            var max = (BigInteger)shortElement.MaxValue;

            var b = RandomBigIntegerBelow(max - min + 1);
            b += shortElement.MinValue;

            return (short)b;
        }

        private float GenerateFloat(FloatElement floatElement)
        {
            var randDouble = GenerateDouble(new DoubleElement
            {
                Type = "Double",
                MinValue = (double)floatElement.MinValue,
                MaxValue = (double)floatElement.MaxValue
            });

            return (float)randDouble;
        }

        private double GenerateDouble(DoubleElement doubleElement)
        {
            return _random.NextDouble() * (doubleElement.MaxValue - doubleElement.MinValue) + doubleElement.MinValue;
        }

        private decimal GenerateDecimal(DecimalElement decimalElement)
        {
            var randDouble = GenerateDouble(new DoubleElement
            {
                Type = "Double",
                MinValue = (double)decimalElement.MinValue,
                MaxValue = (double)decimalElement.MaxValue
            });

            return (decimal)randDouble;
        }

        private BigInteger RandomBigIntegerBelow(BigInteger n)
        {
            byte[] bytes = n.ToByteArray();
            BigInteger r;

            do
            {
                _random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                r = new BigInteger(bytes);
            } while (r >= n);

            return r;
        }
    }
}