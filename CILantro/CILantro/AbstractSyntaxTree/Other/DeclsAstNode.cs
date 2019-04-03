using CILantro.Exceptions;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("decls")]
    public class DeclsAstNode : AstNodeBase
    {
        public CilDecls Decls { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                Decls = new CilDecls
                {
                    AssemblyRefs = new List<CilAssemblyRef>(),
                    Classes = new List<CilClass>()
                };

                return;
            }

            // decls + decl
            var declsChildren = AstChildren.Empty()
                .Add<DeclsAstNode>()
                .Add<DeclAstNode>();
            if (declsChildren.PopulateWith(parseNode))
            {
                Decls = declsChildren.Child1.Decls;

                var declType = declsChildren.Child2.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified.");

                switch (declType.Value)
                {
                    case DeclType.AssemblyRef:
                        Decls.AssemblyRefs.Add(declsChildren.Child2.AssemblyRefDecl);
                        break;
                    case DeclType.Assembly:
                        // TODO: handle
                        break;
                    case DeclType.ImageBase:
                        // TODO: handle
                        break;
                    case DeclType.Module:
                        // TODO: handle
                        break;
                    case DeclType.FileAlignment:
                        // TODO: handle
                        break;
                    case DeclType.StackReserve:
                        // TODO: handle
                        break;
                    case DeclType.Subsystem:
                        // TODO: handle
                        break;
                    case DeclType.CorFlags:
                        // TODO: handle
                        break;
                    case DeclType.Class:
                        Decls.Classes.Add(declsChildren.Child2.ClassDecl);
                        break;
                    case DeclType.ManifestRes:
                        // TODO: handle
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