using System;

namespace TP_CSF_Identifiers_UnderscoresAndLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            var ___thisIsAnIdentifierWithUnderscoresAtTheBeginning = int.Parse(Console.ReadLine());
            var ___thisIsAnotherIdentifierWithUnderscoresAtTheBeginning = int.Parse(Console.ReadLine());

            Console.WriteLine(___thisIsAnIdentifierWithUnderscoresAtTheBeginning + ___thisIsAnotherIdentifierWithUnderscoresAtTheBeginning);
        }
    }
}