using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("implClause")]
    public class ImplClauseAstNode : AstNodeBase
    {
        public List<CilClassName> ClassNames { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                // TODO: handle
                return;
            }

            // _("implements") + classNames
            var implementsChildren = AstChildren.Empty()
                .Add("implements")
                .Add<ClassNamesAstNode>();
            if (implementsChildren.PopulateWith(parseNode))
            {
                ClassNames = implementsChildren.Child2.ClassNames;

                return;
            }

            throw new NotImplementedException();
        }
    }
}