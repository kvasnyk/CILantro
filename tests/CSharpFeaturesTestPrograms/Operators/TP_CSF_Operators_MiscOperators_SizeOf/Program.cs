using System;

namespace TP_CSF_Operators_MiscOperators_SizeOf
{
    class Program
    {
        static void Main(string[] args)
        {
            var sByteSize = sizeof(sbyte);
            Console.WriteLine(sByteSize);

            var shortSize = sizeof(short);
            Console.WriteLine(shortSize);

            var intSize = sizeof(int);
            Console.WriteLine(intSize);

            var decimalSize = sizeof(decimal);
            Console.WriteLine(decimalSize);

            var doubleSize = sizeof(double);
            Console.WriteLine(doubleSize);

            var floatSize = sizeof(float);
            Console.WriteLine(floatSize);

            var uIntSize = sizeof(uint);
            Console.WriteLine(uIntSize);

            var uShortSize = sizeof(ushort);
            Console.WriteLine(uShortSize);

            var byteSize = sizeof(byte);
            Console.WriteLine(byteSize);

            var longSize = sizeof(long);
            Console.WriteLine(longSize);
        }
    }
}