using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("ddBody")]
    public class DdBodyAstNode : AstNodeBase
    {
        public CilData Data { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // ddItem
            var ddItemChildren = AstChildren.Empty()
                .Add<DdItemAstNode>();
            if (ddItemChildren.PopulateWith(parseNode))
            {
                Data = new CilData
                {
                    Items = new List<CilDataItem> { ddItemChildren.Child1.DataItem }
                };

                return;
            }

            throw new NotImplementedException();
        }
    }
}