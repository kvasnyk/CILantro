using System;

namespace TP_CSF_Identifiers_LettersAndUnderscores
{
    class Program
    {
        static void Main(string[] args)
        {
            var this_is_an_identifier_with_some_letters_and_underscores = int.Parse(Console.ReadLine());
            var this_is_another_identifier_with_some_letters_and_underscores = int.Parse(Console.ReadLine());

            Console.WriteLine(this_is_an_identifier_with_some_letters_and_underscores + this_is_another_identifier_with_some_letters_and_underscores);
        }
    }
}