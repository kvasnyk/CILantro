using CILantro.Exceptions;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyRefDecls")]
    public class AssemblyRefDeclsAstNode : AstNodeBase
    {
        public CilAssemblyRefDecls AssemblyRefDecls { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                AssemblyRefDecls = new CilAssemblyRefDecls
                {
                    PublicKeyTokens = new List<byte[]>(),
                    Versions = new List<CilAssemblyVersion>()
                };

                return;
            }

            // assemblyRefDecls + assemblyRefDecl
            var assemblyRefDeclsChildren = AstChildren.Empty()
                .Add<AssemblyRefDeclsAstNode>()
                .Add<AssemblyRefDeclAstNode>();
            if (assemblyRefDeclsChildren.PopulateWith(parseNode))
            {
                AssemblyRefDecls = assemblyRefDeclsChildren.Child1.AssemblyRefDecls;

                var declType = assemblyRefDeclsChildren.Child2.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified.");

                switch (declType.Value)
                {
                    case AssemblyRefDeclType.PublicKeyToken:
                        AssemblyRefDecls.PublicKeyTokens.Add(assemblyRefDeclsChildren.Child2.PublicKeyToken);
                        break;
                    case AssemblyRefDeclType.Ver:
                        AssemblyRefDecls.Versions.Add(assemblyRefDeclsChildren.Child2.Version);
                        break;
                    default:
                        throw new AstNodeException($"\"{nameof(declType)}\" cannot be recognized.");
                }

                return;
            }

            throw new InitAstNodeException(nameof(AssemblyRefDeclsAstNode));
        }
    }
}