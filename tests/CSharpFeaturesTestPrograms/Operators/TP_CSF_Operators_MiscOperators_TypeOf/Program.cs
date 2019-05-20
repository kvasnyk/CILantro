using System;

namespace TP_CSF_Operators_MiscOperators_TypeOf
{
    class Program
    {
        static void Main(string[] args)
        {
            var sByteType = typeof(sbyte);
            Console.WriteLine(sByteType.Name);

            var shortType = typeof(short);
            Console.WriteLine(shortType.Name);

            var intType = typeof(int);
            Console.WriteLine(intType.Name);

            var stringType = typeof(string);
            Console.WriteLine(stringType.Name);

            var doubleType = typeof(double);
            Console.WriteLine(doubleType.Name);

            var floatType = typeof(float);
            Console.WriteLine(floatType.Name);

            var uIntType = typeof(uint);
            Console.WriteLine(uIntType.Name);

            var uShortType = typeof(ushort);
            Console.WriteLine(uShortType.Name);

            var typeType = typeof(Type);
            Console.WriteLine(typeType.Name);

            var objectType = typeof(object);
            Console.WriteLine(objectType.Name);
        }
    }
}