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

        public InputFactory(InputOutput input, Random random = null)
        {
            _input = input;
            _random = random ?? new Random(Guid.NewGuid().GetHashCode());
        }

        public string GenerateRandomInput()
        {
            if (_input.IsEmpty)
                return string.Empty;

            var builder = new StringBuilder();

            foreach (var inputLine in _input.Lines)
            {
                if (inputLine.IsRepeatBlock)
                {
                    builder.Append(GenerateRandomRepeatBlockInput(inputLine.RepeatBlockInputOutput, inputLine.RepeatBlockMin, inputLine.RepeatBlockMax));
                    continue;
                }

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
                    else if (inputElement is ConstStringElement constStringElement)
                    {
                        builder.Append(constStringElement.Value);
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

            var b = RandomBigIntegerBetween(min, max, byteElement.ExcludeZero);

            return (byte)b;
        }

        private int GenerateInt(IntElement intElement)
        {
            var min = (BigInteger)intElement.MinValue;
            var max = (BigInteger)intElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, intElement.ExcludeZero);

            return (int)b;
        }

        private long GenerateLong(LongElement longElement)
        {
            var min = (BigInteger)longElement.MinValue;
            var max = (BigInteger)longElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, longElement.ExcludeZero);

            return (long)b;
        }

        private sbyte GenerateSbyte(SbyteElement sbyteElement)
        {
            var min = (BigInteger)sbyteElement.MinValue;
            var max = (BigInteger)sbyteElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, sbyteElement.ExcludeZero);

            return (sbyte)b;
        }

        private uint GenerateUint(UintElement uintElement)
        {
            var min = (BigInteger)uintElement.MinValue;
            var max = (BigInteger)uintElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, uintElement.ExcludeZero);

            return (uint)b;
        }

        private ulong GenerateUlong(UlongElement ulongElement)
        {
            var min = (BigInteger)ulongElement.MinValue;
            var max = (BigInteger)ulongElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, ulongElement.ExcludeZero);

            return (ulong)b;
        }

        private ushort GenerateUshort(UshortElement ushortElement)
        {
            var min = (BigInteger)ushortElement.MinValue;
            var max = (BigInteger)ushortElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, ushortElement.ExcludeZero);

            return (ushort)b;
        }

        private short GenerateShort(ShortElement shortElement)
        {
            var min = (BigInteger)shortElement.MinValue;
            var max = (BigInteger)shortElement.MaxValue;

            var b = RandomBigIntegerBetween(min, max, shortElement.ExcludeZero);

            return (short)b;
        }

        private float GenerateFloat(FloatElement floatElement)
        {
            var randDouble = GenerateDouble(new DoubleElement
            {
                Type = "Double",
                MinValue = (double)floatElement.MinValue,
                MaxValue = (double)floatElement.MaxValue,
                ExcludeZero = floatElement.ExcludeZero
            });

            return (float)randDouble;
        }

        private double GenerateDouble(DoubleElement doubleElement)
        {
            double result = 0;
            do
            {
                result = _random.NextDouble() * (doubleElement.MaxValue - doubleElement.MinValue) + doubleElement.MinValue;
            } while (result == 0 && doubleElement.ExcludeZero);

            return result;
        }

        private decimal GenerateDecimal(DecimalElement decimalElement)
        {
            var randDouble = GenerateDouble(new DoubleElement
            {
                Type = "Double",
                MinValue = (double)decimalElement.MinValue,
                MaxValue = (double)decimalElement.MaxValue,
                ExcludeZero = decimalElement.ExcludeZero
            });

            return (decimal)randDouble;
        }

        private BigInteger RandomBigIntegerBetween(BigInteger a, BigInteger b, bool excludeZero)
        {
            var diff = b - a + 1;
            byte[] bytes = diff.ToByteArray();
            BigInteger r;

            do
            {
                _random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                r = new BigInteger(bytes);
            } while (r >= diff || (excludeZero && r + a == 0));

            return r + a;
        }

        private string GenerateRandomRepeatBlockInput(InputOutput repeatBlockIo, string repeatBlockMin, string repeatBlockMax)
        {
            var builder = new StringBuilder();

            var innerFactory = new InputFactory(repeatBlockIo, _random);

            int min;
            int max;

            min = int.Parse(repeatBlockMin);
            max = int.Parse(repeatBlockMax);

            var lines = _random.Next(min, max + 1);

            for (int i = 0; i < lines; i++)
                builder.Append(innerFactory.GenerateRandomInput());

            return builder.ToString();
        }
    }
}