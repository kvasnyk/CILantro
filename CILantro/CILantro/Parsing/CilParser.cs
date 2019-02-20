using Irony.Parsing;

namespace CILantro.Parsing
{
    public class CilParser
    {
        private readonly Parser _ironyParser;

        public CilParser()
        {
            _ironyParser = new Parser(new CilGrammar());
        }

        public void Parse(string sourceCode)
        {
            _ironyParser.Parse(sourceCode);
        }
    }
}