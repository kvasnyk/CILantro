using CILantro.Exceptions;
using CILantro.ProgramStructure;
using CILantro.Utils;
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
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                return;
            }

            // assemblyRefDecls + assemblyRefDecl
            var assemblyRefDeclsChildren = AstChildren.Empty()
                .Add<AssemblyRefDeclsAstNode>()
                .Add<AssemblyRefDeclAstNode>();
            if (assemblyRefDeclsChildren.PopulateWith(parseNode))
            {
                PublicKeyToken = assemblyRefDeclsChildren.Child1.PublicKeyToken;
                Version = assemblyRefDeclsChildren.Child1.Version;

                var declType = assemblyRefDeclsChildren.Child2.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified.");

                switch (declType.Value)
                {
                    case AssemblyRefDeclType.PublicKeyToken:
                        PublicKeyToken = assemblyRefDeclsChildren.Child2.PublicKeyToken;
                        break;
                    case AssemblyRefDeclType.Ver:
                        Version = assemblyRefDeclsChildren.Child2.Version;
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