using CILantro.Exceptions;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("manifestResHead")]
    public class ManifestResHeadAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".mresource") + manresAttr + name1
            var children = AstChildren.Empty()
                .Add(".mresource")
                .Add<ManresAttrAstNode>()
                .Add<Name1AstNode>();
            if (children.PopulateWith(parseNode))
            {
                // TODO: implement something

                return;
            }

            throw new InitAstNodeException(nameof(ManifestResHeadAstNode));
        }
    }
}