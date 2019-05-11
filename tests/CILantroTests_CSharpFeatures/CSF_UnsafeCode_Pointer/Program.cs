using System;

namespace CSF_UnsafeCode_Pointer
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            var n = 20;
            int* p = &n;

            Console.WriteLine(n);
            Console.WriteLine(*p);
        }
    }
}
