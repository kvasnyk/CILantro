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

            var length = _random.Next(stringElement.MinLength, stringElement.MaxLength + 1);

            return new string(Enumerable.Repeat(0, length).Select(x => possibleChars[_random.Next(0, possibleChars.Length)]).ToArray());
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
    }
}