using System;

namespace TP_CSF_Arrays_JaggedArrayInitialization
{
    /// <summary>
    /// DESC: Reads n, m - integers and writes out m-th letter in n-th month's name.
    /// 
    /// IN:
    /// n - integer
    /// m - integer
    /// 
    /// OUT:
    /// m-th letter of n-th month's name or '-' otherwise
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var months = new char[][]
            {
                new char[] { 'J', 'a', 'n', 'u', 'a', 'r', 'y' },
                new char[] { 'F', 'e', 'b', 'r', 'u', 'a', 'r', 'y' },
                new char[] { 'M', 'a', 'r', 'c', 'h' },
                new char[] { 'A', 'p', 'r', 'i', 'l' },
                new char[] { 'M', 'a', 'y' },
                new char[] { 'J', 'u', 'n', 'e' },
                new char[] { 'J', 'u', 'l', 'y' },
                new char[] { 'A', 'u', 'g', 'u', 's', 't' },
                new char[] { 'S', 'e', 'p', 't', 'e', 'm', 'b', 'e', 'r' },
                new char[] { 'O', 'c', 't', 'o', 'b', 'e', 'r' },
                new char[] { 'N', 'o', 'v', 'e', 'm', 'b', 'e', 'r' },
                new char[] { 'D', 'e', 'c', 'e', 'm', 'b', 'e', 'r' }
            };

            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            if (n < months.Length && m < months[n].Length) Console.WriteLine(months[n][m]);
            else Console.WriteLine('-');
        }
    }
}