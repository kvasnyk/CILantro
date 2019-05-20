using System;

namespace TP_CSF_Identifiers_LettersOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            var thisIsAnIdentifierWhichContainsLettersOnly = int.Parse(Console.ReadLine());
            var thisIsAnotherIdentifierWhichContainsLettersOnly = int.Parse(Console.ReadLine());

            Console.WriteLine(thisIsAnIdentifierWhichContainsLettersOnly + thisIsAnotherIdentifierWhichContainsLettersOnly);
        }
    }
}