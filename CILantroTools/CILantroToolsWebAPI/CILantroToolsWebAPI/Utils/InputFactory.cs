using CILantroToolsWebAPI.Models.Tests.InputOutput;
using CILantroToolsWebAPI.Models.Tests.InputOutput.Elements;
using System;
using System.Linq;
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
            _random = new Random();
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
                }

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
            var result = _random.Next(byteElement.MinValue, byteElement.MaxValue + 1);
            return (byte)result;
        }

        private int GenerateInt(IntElement intElement)
        {
            var buf = new byte[4];
            _random.NextBytes(buf);
            var randInt = BitConverter.ToInt32(buf, 0);
            var result = (Math.Abs(randInt % (intElement.MaxValue - intElement.MinValue)) + intElement.MinValue);
            return result;
        }

        private long GenerateLong(LongElement longElement)
        {
            var buf = new byte[8];
            _random.NextBytes(buf);
            var randLong = BitConverter.ToInt64(buf, 0);
            var result = (Math.Abs(randLong % (longElement.MaxValue - longElement.MinValue)) + longElement.MinValue);
            return result;
        }

        private sbyte GenerateSbyte(SbyteElement sbyteElement)
        {
            var result = _random.Next(sbyteElement.MinValue, sbyteElement.MaxValue + 1);
            return (sbyte)result;
        }

        private uint GenerateUint(UintElement uintElement)
        {
            var buf = new byte[4];
            _random.NextBytes(buf);
            var randUint = BitConverter.ToUInt32(buf, 0);
            var result = (randUint % (uintElement.MaxValue - uintElement.MinValue)) + uintElement.MinValue;
            return result;
        }

        private ulong GenerateUlong(UlongElement ulongElement)
        {
            var buf = new byte[8];
            _random.NextBytes(buf);
            var randUlong = BitConverter.ToUInt64(buf, 0);
            var result = (randUlong % (ulongElement.MaxValue - ulongElement.MinValue)) + ulongElement.MinValue;
            return result;
        }

        private ushort GenerateUshort(UshortElement ushortElement)
        {
            var result = _random.Next(ushortElement.MinValue, ushortElement.MaxValue + 1);
            return (ushort)result;
        }

        private short GenerateShort(ShortElement shortElement)
        {
            var result = _random.Next(shortElement.MinValue, shortElement.MaxValue + 1);
            return (short)result;
        }

        private float GenerateFloat(FloatElement floatElement)
        {
            var buf = new byte[sizeof(float)];
            _random.NextBytes(buf);
            var randFloat = BitConverter.ToSingle(buf, 0);
            var result = (Math.Abs(randFloat % (floatElement.MaxValue - floatElement.MinValue)) + floatElement.MinValue);
            return result;
        }

        private double GenerateDouble(DoubleElement doubleElement)
        {
            var buf = new byte[sizeof(double)];
            _random.NextBytes(buf);
            var randDouble = BitConverter.ToDouble(buf, 0);
            var result = (Math.Abs(randDouble % (doubleElement.MaxValue - doubleElement.MinValue)) + doubleElement.MinValue);
            return result;
        }

        private decimal GenerateDecimal(DecimalElement decimalElement)
        {
            var buf = new byte[sizeof(double)];
            _random.NextBytes(buf);
            var randDouble = BitConverter.ToDouble(buf, 0);
            var result = (Math.Abs(randDouble % ((double)decimalElement.MaxValue - (double)decimalElement.MinValue)) + (double)decimalElement.MinValue);
            return (decimal)result;
        }
    }
}