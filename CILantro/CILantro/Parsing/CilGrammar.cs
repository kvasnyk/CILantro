using Irony.Parsing;

namespace CILantro.Parsing
{
    public class CilGrammar : Grammar
    {
        public CilGrammar()
            : base(true)
        {
            var decls = new NonTerminal("decls");
            decls.Rule = Empty;

            Root = decls;
        }
    }
}