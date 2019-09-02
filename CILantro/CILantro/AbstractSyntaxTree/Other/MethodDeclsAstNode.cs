using CILantro.Exceptions;
using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System.Collections.Generic;

namespace CILantro.AbstractSyntaxTree.Other
{
    [AstNode("methodDecls")]
    public class MethodDeclsAstNode : AstNodeBase
    {
        public CilMethodDecls MethodDecls { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // Empty
            var emptyChildren = AstChildren.Empty();
            if (emptyChildren.PopulateWith(parseNode))
            {
                MethodDecls = new CilMethodDecls
                {
                    IsEntryPoint = false,
                    Instructions = new List<Instructions.CilInstruction>(),
                    InstructionsLabels = new List<string>(),
                    Locals = new List<CilSigArg>()
                };

                return;
            }

            // methodDecls + methodDecl
            var methodDeclsChildren = AstChildren.Empty()
                .Add<MethodDeclsAstNode>()
                .Add<MethodDeclAstNode>();
            if (methodDeclsChildren.PopulateWith(parseNode))
            {
                MethodDecls = methodDeclsChildren.Child1.MethodDecls;

                var declType = methodDeclsChildren.Child2.DeclType;

                if (!declType.HasValue)
                    throw new AstNodeException($"\"{nameof(declType)}\" is not specified.");

                switch (declType)
                {
                    case MethodDeclType.EntryPoint:
                        if (MethodDecls.IsEntryPoint)
                            throw new ParserException("Multiple .entrypoint declarations.");
                        MethodDecls.IsEntryPoint = true;
                        break;
                    case MethodDeclType.Instruction:
                        var instruction = methodDeclsChildren.Child2.Instruction;
                        instruction.Labels = MethodDecls.InstructionsLabels;
                        MethodDecls.Instructions.Add(instruction);

                        MethodDecls.InstructionsLabels = new List<string>();
                        break;
                    case MethodDeclType.MaxStack:
                        // TODO - handle
                        break;
                    case MethodDeclType.Label:
                        MethodDecls.InstructionsLabels.Add(methodDeclsChildren.Child2.Label);
                        break;
                    case MethodDeclType.CustomAttr:
                        // TODO - handle
                        break;
                    case MethodDeclType.Locals:
                        MethodDecls.Locals = methodDeclsChildren.Child2.LocalsSigArgs;
                        break;
                    case MethodDeclType.ParamInit:
                        // TODO - handle
                        break;
                    default:
                        throw new AstNodeException($"\"{nameof(declType)}\" cannot be recognized.");
                }

                return;
            }

            throw new InitAstNodeException(nameof(MethodDeclsAstNode));
        }
    }
}