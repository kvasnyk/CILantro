using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("labels")]
    public class LabelsAstNode : AstNodeBase
    {
        public List<CilLabel> Labels { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // id
            var idChildren = AstChildren.Empty()
                .Add<IdAstNode>();
            if (idChildren.PopulateWith(parseNode))
            {
                var label = new CilLabel
                {
                    Id = idChildren.Child1.Value
                };
                Labels = new List<CilLabel> { label };

                return;
            }

            // id + _(",") + labels
            var idlabelsChildren = AstChildren.Empty()
                .Add<IdAstNode>()
                .Add(",")
                .Add<LabelsAstNode>();
            if (idlabelsChildren.PopulateWith(parseNode))
            {
                var label = new CilLabel
                {
                    Id = idlabelsChildren.Child1.Value
                };
                Labels = (new List<CilLabel> { label }).Concat(idlabelsChildren.Child3.Labels).ToList();

                return;
            }

            throw new NotImplementedException();
        }
    }
}