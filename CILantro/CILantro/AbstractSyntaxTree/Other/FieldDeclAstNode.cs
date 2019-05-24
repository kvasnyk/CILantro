using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("fieldDecl")]
    public class FieldDeclAstNode : AstNodeBase
    {
        public CilField Field { get; private set; }

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
                Field = new CilField
                {
                    Name = fieldChildren.Child5.Value,
                    Type = fieldChildren.Child4.Type,
                    IsStatic = fieldChildren.Child3.IsStatic,
                    InitValue = fieldChildren.Child7.InitValue
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}