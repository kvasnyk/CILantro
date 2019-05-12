using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("fieldDecl")]
    public class FieldDeclAstNode : AstNodeBase
    {
        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // _(".field") + repeatOpt + fieldAttr + type + id + atOpt + initOpt
            var fieldChildren = AstChildren.Empty()
                .Add(".field")
                .Add<RepeatOptAstNode>()
                .Add<FieldAttrAstNode>()
                .Add<TypeAstNode>()
                .Add<IdAstNode>()
                .Add<AtOptAstNode>()
                .Add<InitOptAstNode>();
            if (fieldChildren.PopulateWith(parseNode))
            {
                // TODO: handle

                return;
            }

            throw new NotImplementedException();
        }
    }
}