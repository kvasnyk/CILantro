using CILantro.Exceptions;
using CILantro.Extensions;
using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("decls")]
    public class DeclsAstNode : AstNodeBase
    {
        public CilProgram Program { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var declsNode = parseNode.FindChild<DeclsAstNode>();
            var declNode = parseNode.FindChild<DeclAstNode>();

            // Empty
            if (parseNode.ChildNodes.IsEmpty())
            {
                Program = new CilProgram
                {
                    AssemblyRefs = new List<CilAssemblyRef>()
                };

                return;
            }

            // decls + decl
            if (declsNode != null && declNode != null)
            {
                Program = declsNode.Program;

                var declType = declNode.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified for \"{nameof(declNode)}\".");

                switch (declType.Value)
                {
                    case DeclType.AssemblyRef:
                        Program.AssemblyRefs.Add(declNode.AssemblyRefDecl);
                        break;
                    default:
                        throw new AstNodeException($"\"{nameof(declType)}\" cannot be recognized.");
                }

                return;
            }

            throw new NotImplementedException();
        }
    }
}