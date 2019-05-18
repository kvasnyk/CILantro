using System;

namespace CSF_Classes_Constructor_ManyArgs
{
    public class Test
    {
        private int _a;

        private int _b;

        private int _c;

        private int _d;

        private int _e;

        public Test(int a)
        {
            _a = a;
        }

        public Test(int a, int b)
            : this(a)
        {
            _b = b;
        }

        public Test(int a, int b, int c)
            : this(a, b)
        {
            _c = c;
        }

        public Test(int a, int b, int c, int d)
            : this(a, b, c)
        {
            _d = d;
        }

        public Test(int a, int b, int c, int d, int e)
            : this(a, b, c, d)
        {
            _e = e;
        }

        public void WriteSum()
        {
            Console.WriteLine(_a + _b + _c + _d + _e);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            var a = int.Parse(line[0]);
            var b = int.Parse(line[1]);
            var c = int.Parse(line[2]);
            var d = int.Parse(line[3]);
            var e = int.Parse(line[4]);

            var test1 = new Test(a);
            var test2 = new Test(a, b);
            var test3 = new Test(a, b, c);
            var test4 = new Test(a, b, c, d);
            var test5 = new Test(a, b, c, d, e);

            test1.WriteSum();
            test2.WriteSum();
            test3.WriteSum();
            test4.WriteSum();
            test5.WriteSum();
        }
    }
}