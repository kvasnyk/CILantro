using CILantro.Exceptions;
using CILantro.ProgramStructure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum AssemblyRefDeclType
    {
        PublicKeyToken,
        Ver
    }

    [AstNode("assemblyRefDecl")]
    public class AssemblyRefDeclAstNode : AstNodeBase
    {
        public AssemblyRefDeclType? DeclType { get; private set; }

        public byte[] PublicKeyToken { get; private set; }

        public CilAssemblyVersion Version { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // asmOrRefDecl
            var asmOrRefDeclChildren = AstChildren.Empty()
                .Add<AsmOrRefDeclAstNode>();
            if (asmOrRefDeclChildren.PopulateWith(parseNode))
            {
                var declType = asmOrRefDeclChildren.Child1.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified.");

                switch (declType.Value)
                {
                    case AsmOrRefDeclType.Ver:
                        DeclType = AssemblyRefDeclType.Ver;
                        Version = asmOrRefDeclChildren.Child1.Version;
                        break;
                    default:
                        throw new AstNodeException($"\"{nameof(declType)}\" cannot be recognized.");
                }

                return;
            }

            // publicKeyTokenHead + bytes + _(")")
            var publicKeyTokenChildren = AstChildren.Empty()
                .Add<PublicKeyTokenHeadAstNode>()
                .Add<BytesAstNode>()
                .Add(")");
            if (publicKeyTokenChildren.PopulateWith(parseNode))
            {
                DeclType = AssemblyRefDeclType.PublicKeyToken;
                PublicKeyToken = publicKeyTokenChildren.Child2.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}