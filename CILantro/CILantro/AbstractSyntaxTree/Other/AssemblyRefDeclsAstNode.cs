using CILantro.Exceptions;
using CILantro.Extensions;
using CILantro.Model;
using Irony.Ast;
using Irony.Parsing;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("assemblyRefDecls")]
    public class AssemblyRefDeclsAstNode : AstNodeBase
    {
        // TODO: is only one value possible or should it be changed to list?
        public byte[] PublicKeyToken { get; private set; }

        // TODO: is only one value possible or should it be changed to list?
        public CilAssemblyVersion Version { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            var assemblyRefDeclsAstNode = parseNode.FindChild<AssemblyRefDeclsAstNode>();
            var assemblyRefDeclAstNode = parseNode.FindChild<AssemblyRefDeclAstNode>();

            // Empty
            if (parseNode.ChildNodes.IsEmpty())
            {
                return;
            }

            // assemblyRefDecls + assemblyRefDecl
            if (assemblyRefDeclsAstNode != null && assemblyRefDeclAstNode != null)
            {
                PublicKeyToken = assemblyRefDeclsAstNode.PublicKeyToken;
                Version = assemblyRefDeclsAstNode.Version;

                var declType = assemblyRefDeclAstNode.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified for \"{nameof(assemblyRefDeclAstNode)}\".");

                switch (declType.Value)
                {
                    case AssemblyRefDeclType.PublicKeyToken:
                        PublicKeyToken = assemblyRefDeclAstNode.PublicKeyToken;
                        break;
                    case AssemblyRefDeclType.Ver:
                        Version = assemblyRefDeclAstNode.Version;
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