﻿using CILantro.Structure;
using CILantro.Utils;
using Irony.Ast;
using Irony.Parsing;
using System;

namespace CILantro.AbstractSyntaxTree.Other
{
    public enum DeclType
    {
        Assembly,
        AssemblyRef,
        Class,
        CorFlags,
        FileAlignment,
        ImageBase,
        Module,
        StackReserve,
        Subsystem,
        ManifestRes,
        Method,
        CustomAttribute,
        Data
    }

    [AstNode("decl")]
    public class DeclAstNode : AstNodeBase
    {
        public DeclType? DeclType { get; private set; }

        public CilAssemblyRef AssemblyRefDecl { get; private set; }

        public CilAssembly AssemblyDecl { get; private set; }

        public CilClass ClassDecl { get; private set; }

        public CilMethod MethodDecl { get; private set; }

        public CilData DataDecl { get; private set; }

        public string DataId { get; private set; }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // classHead + _("{") + classDecls + _("}")
            var classChildren = AstChildren.Empty()
                .Add<ClassHeadAstNode>()
                .Add("{")
                .Add<ClassDeclsAstNode>()
                .Add("}");
            if (classChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.Class;

                ClassDecl = new CilClass
                {
                    Name = new CilClassName
                    {
                        ClassName = classChildren.Child1.ClassName
                    },
                    Methods = classChildren.Child3.ClassDecls.Methods,
                    Fields = classChildren.Child3.ClassDecls.Fields,
                    Classes = classChildren.Child3.ClassDecls.Classes,
                    ExtendsName = classChildren.Child1.ExtendsClassName,
                    Attributes = classChildren.Child1.ClassAttributes
                };

                return;
            }

            // assemblyHead + _("{") + assemblyDecls + _("}")
            var assemblyChildren = AstChildren.Empty()
                .Add<AssemblyHeadAstNode>()
                .Add("{")
                .Add<AssemblyDeclsAstNode>()
                .Add("}");
            if (assemblyChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.Assembly;

                AssemblyDecl = new CilAssembly
                {
                    Name = assemblyChildren.Child1.AssemblyName
                };

                return;
            }

            // assemblyRefHead + _("{") + assemblyRefDecls + _("}")
            var assemblyRefChildren = AstChildren.Empty()
                .Add<AssemblyRefHeadAstNode>()
                .Add("{")
                .Add<AssemblyRefDeclsAstNode>()
                .Add("}");
            if (assemblyRefChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.AssemblyRef;
                AssemblyRefDecl = new CilAssemblyRef
                {
                    Name = assemblyRefChildren.Child1.AssemblyName,
                    PublicKeyTokens = assemblyRefChildren.Child3.AssemblyRefDecls.PublicKeyTokens,
                    Versions = assemblyRefChildren.Child3.AssemblyRefDecls.Versions
                };

                return;
            }

            // moduleHead
            var moduleChildren = AstChildren.Empty()
                .Add<ModuleHeadAstNode>();
            if (moduleChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.Module;

                return;
            }

            // _(".file") + _("alignment") + int32
            var fileAlignmentChildren = AstChildren.Empty()
                .Add(".file")
                .Add("alignment")
                .Add<Int32AstNode>();
            if (fileAlignmentChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.FileAlignment;

                return;
            }

            // _(".subsystem") + int32
            var subsystemChildren = AstChildren.Empty()
                .Add(".subsystem")
                .Add<Int32AstNode>();
            if (subsystemChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.Subsystem;

                return;
            }

            // _(".corflags") + int32
            var corFlagsChildren = AstChildren.Empty()
                .Add(".corflags")
                .Add<Int32AstNode>();
            if (corFlagsChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.CorFlags;

                return;
            }

            // _(".imagebase") + int64
            var imageBaseChildren = AstChildren.Empty()
                .Add(".imagebase")
                .Add<Int64AstNode>();
            if (imageBaseChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.ImageBase;

                return;
            }

            // _(".stackreserve") + int64
            var stackReserveChildren = AstChildren.Empty()
                .Add(".stackreserve")
                .Add<Int64AstNode>();
            if (stackReserveChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.StackReserve;

                return;
            }

            // manifestResHead + _("{") + manifestResDecls + _("}")
            var manifestResChildren = AstChildren.Empty()
                .Add<ManifestResHeadAstNode>()
                .Add("{")
                .Add<ManifestResDeclsAstNode>()
                .Add("}");
            if (manifestResChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.ManifestRes;

                return;
            }

            // methodHead + methodDecls + _("}")
            var methodChildren = AstChildren.Empty()
                .Add<MethodHeadAstNode>()
                .Add<MethodDeclsAstNode>()
                .Add("}");
            if (methodChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.Method;

                MethodDecl = new CilMethod
                {
                    Name = methodChildren.Child1.MethodName,
                    IsEntryPoint = methodChildren.Child2.MethodDecls.IsEntryPoint,
                    Instructions = methodChildren.Child2.MethodDecls.Instructions,
                    Locals = methodChildren.Child2.MethodDecls.Locals
                };

                return;
            }

            // customAttrDecl
            var customAttrDeclChildren = AstChildren.Empty()
                .Add<CustomAttrDeclAstNode>();
            if (customAttrDeclChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.CustomAttribute;

                return;
            }

            // dataDecl
            var dataDeclChildren = AstChildren.Empty()
                .Add<DataDeclAstNode>();
            if (dataDeclChildren.PopulateWith(parseNode))
            {
                DeclType = Other.DeclType.Data;
                DataDecl = dataDeclChildren.Child1.Data;
                DataId = dataDeclChildren.Child1.DataId;

                return;
            }

            throw new NotImplementedException();
        }
    }
}