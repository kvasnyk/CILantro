using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("dataDecl")]
    public class DataDeclAstNode : AstNodeBase
    {
        public CilData Data { get; private set; }

        public string DataId { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ddHead + ddBody
            var headbodyChildren = AstChildren.Empty()
                .Add<DdHeadAstNode>()
                .Add<DdBodyAstNode>();
            if (headbodyChildren.PopulateWith(parseNode))
            {
                Data = headbodyChildren.Child2.Data;
                DataId = headbodyChildren.Child1.DataId;

                return;
            }

            throw new NotImplementedException();
        }
    }
}