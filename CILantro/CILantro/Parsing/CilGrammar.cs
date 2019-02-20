using Irony.Parsing;

namespace CILantro.Parsing
{
    public class CilGrammar : Grammar
    {
        public CilGrammar()
            : base(true)
        {
            var SINGLE_LINE_COMMENT = new CommentTerminal("SINGLE_LINE_COMMENT", "//", "\n", "\r\n");

            NonGrammarTerminals.Add(SINGLE_LINE_COMMENT);

            var decls = new NonTerminal("decls");
            decls.Rule = Empty;

            Root = decls;
        }
    }
}