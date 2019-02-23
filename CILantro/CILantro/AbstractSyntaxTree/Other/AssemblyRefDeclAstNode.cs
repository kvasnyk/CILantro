using CILantro.Exceptions;
using CILantro.Extensions;
using CILantro.Model;
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
            var publicKeyTokenHeadNode = parseNode.FindChild<PublicKeyTokenHeadAstNode>();
            var bytesNode = parseNode.FindChild<BytesAstNode>();
            var asmOrRefDeclNode = parseNode.FindChild<AsmOrRefDeclAstNode>();

            // asmOrRefDecl
            if (asmOrRefDeclNode != null)
            {
                var declType = asmOrRefDeclNode.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified for \"{nameof(asmOrRefDeclNode)}\".");

                switch (declType.Value)
                {
                    case AsmOrRefDeclType.Ver:
                        DeclType = AssemblyRefDeclType.Ver;
                        Version = asmOrRefDeclNode.Version;
                        break;
                    default:
                        throw new AstNodeException($"\"{nameof(declType)}\" cannot be recognized.");
                }

                return;
            }

            // publicKeyTokenHead + bytes + _(")")
            if (publicKeyTokenHeadNode != null)
            {
                DeclType = AssemblyRefDeclType.PublicKeyToken;
                PublicKeyToken = bytesNode.Value;

                return;
            }

            throw new NotImplementedException();
        }
    }
}