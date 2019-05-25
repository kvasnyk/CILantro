using CILantro.AbstractSyntaxTree;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CILantro.Parsing
{
    public class CilGrammar : Grammar
    {
        public CilGrammar()
            : base(true)
        {
            LanguageFlags = LanguageFlags.CreateAst;

            // comments

            var SINGLELINECOMMENT = new CommentTerminal("SINGLELINECOMMENT", "//", "\n", "\r\n");
            ConfigureAstNode(SINGLELINECOMMENT);

            NonGrammarTerminals.Add(SINGLELINECOMMENT);

            // lexical tokens

            // TODO: specify
            var HEXBYTE = new RegexBasedTerminal("HEXBYTE", @"[A-F0-9]{2}"); // DOCS: not specified in ECMA grammar
            ConfigureAstNode(HEXBYTE);

            // TODO: specify
            var DOTTEDNAME = CreateNonTerminal("DOTTEDNAME");
            DOTTEDNAME.Rule = _("TODO: DOTTEDNAME");
            ConfigureAstNode(DOTTEDNAME);

            // TODO: specify
            var ID = new IdentifierTerminal("ID");
            ID.AddPrefix("$", IdOptions.None); // DOCS: ECMA page 110
            ConfigureAstNode(ID);

            // TODO: specify
            var QSTRING = new StringLiteral("QSTRING", "\"");
            ConfigureAstNode(QSTRING);

            // TODO: specify
            var SQSTRING = new StringLiteral("SQSTRING", "'");
            ConfigureAstNode(SQSTRING);

            // TODO: specify
            var INT32 = new NumberLiteral("INT32", NumberOptions.AllowSign | NumberOptions.IntOnly);
            INT32.AddPrefix("0x", NumberOptions.Hex);
            INT32.DefaultIntTypes = new TypeCode[] { TypeCode.Int32 };
            ConfigureAstNode(INT32);

            // TODO: specify
            var INT64 = new NumberLiteral("INT64", NumberOptions.AllowSign | NumberOptions.IntOnly);
            INT64.AddPrefix("0x", NumberOptions.Hex);
            INT64.DefaultIntTypes = new TypeCode[] { TypeCode.Int64 };
            ConfigureAstNode(INT64);

            // TODO: specify
            var FLOAT64 = new NumberLiteral("FLOAT64", NumberOptions.AllowStartEndDot | NumberOptions.AllowSign);
            ConfigureAstNode(FLOAT64);

            // non-terminals

            var decls = CreateNonTerminal("decls");
            var decl = CreateNonTerminal("decl");
            var compQstring = CreateNonTerminal("compQstring");
            var languageDecl = CreateNonTerminal("languageDecl");
            var customAttrDecl = CreateNonTerminal("customAttrDecl");
            var moduleHead = CreateNonTerminal("moduleHead");
            var vtfixupDecl = CreateNonTerminal("vtfixupDecl");
            var vtableDecl = CreateNonTerminal("vtableDecl");
            var nameSpaceHead = CreateNonTerminal("nameSpaceHead");
            var classHead = CreateNonTerminal("classHead");
            var classAttr = CreateNonTerminal("classAttr");
            var extendsClause = CreateNonTerminal("extendsClause");
            var implClause = CreateNonTerminal("implClause");
            var classNames = CreateNonTerminal("classNames");
            var classDecls = CreateNonTerminal("classDecls");
            var classDecl = CreateNonTerminal("classDecl");
            var fieldDecl = CreateNonTerminal("fieldDecl");
            var atOpt = CreateNonTerminal("atOpt");
            var initOpt = CreateNonTerminal("initOpt");
            var repeatOpt = CreateNonTerminal("repeatOpt");
            var customHead = CreateNonTerminal("customHead");
            var customHeadWithOwner = CreateNonTerminal("customHeadWithOwner");
            var memberRef = CreateNonTerminal("memberRef");
            var customType = CreateNonTerminal("customType");
            var ownerType = CreateNonTerminal("ownerType");
            var eventHead = CreateNonTerminal("eventHead");
            var eventDecls = CreateNonTerminal("eventDecls");
            var propHead = CreateNonTerminal("propHead");
            var propDecls = CreateNonTerminal("propDecls");
            var methodHeadPart1 = CreateNonTerminal("methodHeadPart1");
            var methodHead = CreateNonTerminal("methodHead");
            var methAttr = CreateNonTerminal("methAttr");
            var pinvAttr = CreateNonTerminal("pinvAttr");
            var methodName = CreateNonTerminal("methodName");
            var paramAttr = CreateNonTerminal("paramAttr");
            var fieldAttr = CreateNonTerminal("fieldAttr");
            var implAttr = CreateNonTerminal("implAttr");
            var localsHead = CreateNonTerminal("localsHead");
            var methodDecl = CreateNonTerminal("methodDecl");
            var scopeBlock = CreateNonTerminal("scopeBlock");
            var sehBlock = CreateNonTerminal("sehBlock");
            var methodDecls = CreateNonTerminal("methodDecls");
            var dataDecl = CreateNonTerminal("dataDecl");
            var ddHead = CreateNonTerminal("ddHead");
            var tls = CreateNonTerminal("tls");
            var ddBody = CreateNonTerminal("ddBody");
            var ddItemList = CreateNonTerminal("ddItemList");
            var ddItemCount = CreateNonTerminal("ddItemCount");
            var ddItem = CreateNonTerminal("ddItem");
            var fieldInit = CreateNonTerminal("fieldInit");
            var bytearrayhead = CreateNonTerminal("bytearrayhead");
            var bytes = CreateNonTerminal("bytes");
            var hexbytes = CreateNonTerminal("hexbytes");
            var instr_r_head = CreateNonTerminal("instr_r_head");
            var instr_tok_head = CreateNonTerminal("instr_tok_head");
            var methodSpec = CreateNonTerminal("methodSpec");
            var instr = CreateNonTerminal("instr");
            var sigArgs0 = CreateNonTerminal("sigArgs0");
            var sigArgs1 = CreateNonTerminal("sigArgs1");
            var sigArg = CreateNonTerminal("sigArg");
            var name1 = CreateNonTerminal("name1");
            var className = CreateNonTerminal("className");
            var slashedName = CreateNonTerminal("slashedName");
            var typeSpec = CreateNonTerminal("typeSpec");
            var callConv = CreateNonTerminal("callConv");
            var callKind = CreateNonTerminal("callKind");
            var nativeType = CreateNonTerminal("nativeType");
            var type = CreateNonTerminal("type");
            var bounds1 = CreateNonTerminal("bounds1");
            var bound = CreateNonTerminal("bound");
            var labels = CreateNonTerminal("labels");
            var id = CreateNonTerminal("id");
            var int16s = CreateNonTerminal("int16s");
            var int32 = CreateNonTerminal("int32");
            var int64 = CreateNonTerminal("int64");
            var float64 = CreateNonTerminal("float64");
            var secDecl = CreateNonTerminal("secDecl");
            var psetHead = CreateNonTerminal("psetHead");
            var nameValPairs = CreateNonTerminal("nameValPairs");
            var nameValPair = CreateNonTerminal("nameValPair");
            var truefalse = CreateNonTerminal("truefalse");
            var caValue = CreateNonTerminal("caValue");
            var secAction = CreateNonTerminal("secAction");
            var extSourceSpec = CreateNonTerminal("extSourceSpec");
            var fileDecl = CreateNonTerminal("fileDecl");
            var hashHead = CreateNonTerminal("hashHead");
            var assemblyHead = CreateNonTerminal("assemblyHead");
            var asmAttr = CreateNonTerminal("asmAttr");
            var assemblyDecls = CreateNonTerminal("assemblyDecls");
            var assemblyDecl = CreateNonTerminal("assemblyDecl");
            var asmOrRefDecl = CreateNonTerminal("asmOrRefDecl");
            var publicKeyHead = CreateNonTerminal("publicKeyHead");
            var publicKeyTokenHead = CreateNonTerminal("publicKeyTokenHead");
            var localeHead = CreateNonTerminal("localeHead");
            var assemblyRefHead = CreateNonTerminal("assemblyRefHead");
            var assemblyRefDecls = CreateNonTerminal("assemblyRefDecls");
            var assemblyRefDecl = CreateNonTerminal("assemblyRefDecl");
            var comtypeHead = CreateNonTerminal("comtypeHead");
            var exportHead = CreateNonTerminal("exportHead");
            var comtypeDecls = CreateNonTerminal("comtypeDecls");
            var manifestResHead = CreateNonTerminal("manifestResHead");
            var manresAttr = CreateNonTerminal("manresAttr");
            var manifestResDecls = CreateNonTerminal("manifestResDecls");
            var manifestResDecl = CreateNonTerminal("manifestResDecl");

            // instructions

            var INSTR_NONE = CreateNonTerminal("INSTR_NONE");
            var INSTR_VAR = CreateNonTerminal("INSTR_VAR");
            var INSTR_I = CreateNonTerminal("INSTR_I");
            var INSTR_I8 = CreateNonTerminal("INSTR_I8");
            var INSTR_R = CreateNonTerminal("INSTR_R");
            var INSTR_BRTARGET = CreateNonTerminal("INSTR_BRTARGET");
            var INSTR_METHOD = CreateNonTerminal("INSTR_METHOD");
            var INSTR_FIELD = CreateNonTerminal("INSTR_FIELD");
            var INSTR_TYPE = CreateNonTerminal("INSTR_TYPE");
            var INSTR_STRING = CreateNonTerminal("INSTR_STRING");
            var INSTR_SIG = CreateNonTerminal("INSTR_SIG");
            var INSTR_RVA = CreateNonTerminal("INSTR_RVA");
            var INSTR_SWITCH = CreateNonTerminal("INSTR_SWITCH");
            var INSTR_PHI = CreateNonTerminal("INSTR_PHI");
            var INSTR_TOK = CreateNonTerminal("INSTR_TOK");

            INSTR_NONE.Rule =
                _("add") |
                ___("add.ovf") |
                ___("add.ovf.un") |
                _("and") |
                _("arglist") |
                _("break") |
                _("ceq") |
                _("cgt") |
                ___("cgt.un") |
                _("ckfinite") |
                _("clt") |
                ___("clt.un") |
                ___("conv.i") |
                ___("conv.i1") |
                ___("conv.i2") |
                ___("conv.i4") |
                ___("conv.i8") |
                ___("conv.ovf.i") |
                ___("conv.ovf.i.un") |
                ___("conv.ovf.i1") |
                ___("conv.ovf.i1.un") |
                ___("conv.ovf.i2") |
                ___("conv.ovf.i2.un") |
                ___("conv.ovf.i4") |
                ___("conv.ovf.i4.un") |
                ___("conv.ovf.i8") |
                ___("conv.ovf.i8.un") |
                ___("conv.ovf.u") |
                ___("conv.ovf.u.un") |
                ___("conv.ovf.u1") |
                ___("conv.ovf.u1.un") |
                ___("conv.ovf.u2") |
                ___("conv.ovf.u2.un") |
                ___("conv.ovf.u4") |
                ___("conv.ovf.u4.un") |
                ___("conv.ovf.u8") |
                ___("conv.ovf.u8.un") |
                ___("conv.r.un") |
                ___("conv.r4") |
                ___("conv.r8") |
                ___("conv.u") |
                ___("conv.u1") |
                ___("conv.u2") |
                ___("conv.u4") |
                ___("conv.u8") |
                _("cpblk") |
                _("div") |
                ___("div.un") |
                _("dup") |
                _("endfault") |
                _("endfilter") |
                _("endfinally") |
                _("initblk") |
                ___("ldarg.0") |
                ___("ldarg.1") |
                ___("ldarg.2") |
                ___("ldarg.3") |
                ___("ldc.i4.0") |
                ___("ldc.i4.1") |
                ___("ldc.i4.2") |
                ___("ldc.i4.3") |
                ___("ldc.i4.4") |
                ___("ldc.i4.5") |
                ___("ldc.i4.6") |
                ___("ldc.i4.7") |
                ___("ldc.i4.8") |
                ___("ldc.i4.M1") |
                ___("ldc.i4.m1") | // DOCS: non present in ECMA grammar
                ___("ldelem.i") |
                ___("ldelem.i1") |
                ___("ldelem.i2") |
                ___("ldelem.i4") |
                ___("ldelem.i8") |
                ___("ldelem.r4") |
                ___("ldelem.r8") |
                ___("ldelem.ref") |
                ___("ldelem.u1") |
                ___("ldelem.u2") |
                ___("ldelem.u4") |
                ___("ldind.i") |
                ___("ldind.i1") |
                ___("ldind.i2") |
                ___("ldind.i4") |
                ___("ldind.i8") |
                ___("ldind.r4") |
                ___("ldind.r8") |
                ___("ldind.ref") |
                ___("ldind.u1") |
                ___("ldind.u2") |
                ___("ldind.u4") |
                _("ldlen") |
                ___("ldloc.0") |
                ___("ldloc.1") |
                ___("ldloc.2") |
                ___("ldloc.3") |
                _("ldnull") |
                _("localloc") |
                _("mul") |
                ___("mul.ovf") |
                ___("mul.ovf.un") |
                _("neg") |
                _("nop") |
                _("not") |
                _("or") |
                _("pop") |
                _("refanytype") |
                _("rem") |
                ___("rem.un") |
                _("ret") |
                _("rethrow") |
                _("shl") |
                _("shr") |
                ___("shr.un") |
                ___("stelem.i") |
                ___("stelem.i1") |
                ___("stelem.i2") |
                ___("stelem.i4") |
                ___("stelem.i8") |
                ___("stelem.r4") |
                ___("stelem.r8") |
                ___("stelem.ref") |
                ___("stind.i") |
                ___("stind.i1") |
                ___("stind.i2") |
                ___("stind.i4") |
                ___("stind.i8") |
                ___("stind.r4") |
                ___("stind.r8") |
                ___("stind.ref") |
                ___("stloc.0") |
                ___("stloc.1") |
                ___("stloc.2") |
                ___("stloc.3") |
                _("sub") |
                ___("sub.ovf") |
                ___("sub.ovf.un") |
                _("tail.") |
                _("throw") |
                _("volatile.") |
                _("xor");

            // TODO: INSTR_VAR
            INSTR_VAR.Rule =
                _("ladrg") |
                ___("ldarg.s") |
                _("ldarga") |
                ___("ldarga.s") |
                _("ldloc") |
                ___("ldloc.s") |
                _("ldloca") |
                ___("ldloca.s") |
                _("starg") |
                ___("starg.s") |
                _("stloc") |
                ___("stloc.s");

            INSTR_I.Rule =
                ___("ldc.i4") |
                ___("ldc.i4.s") |
                _("unaligned.");

            INSTR_I8.Rule =
                ___("ldc.i8");

            INSTR_R.Rule =
                ___("ldc.r4") |
                ___("ldc.r8");

            // TODO: INSTR_BRTARGET
            INSTR_BRTARGET.Rule =
                _("beq") |
                ___("beq.s") |
                _("bge") |
                ___("bge.s") |
                ___("bge.un") |
                ___("bge.un.s") |
                _("bgt") |
                ___("bgt.s") |
                ___("bgt.un") |
                ___("bgt.un.s") |
                _("ble") |
                ___("ble.s") |
                ___("ble.un") |
                ___("ble.un.s") |
                _("blt") |
                ___("blt.s") |
                ___("blt.un") |
                ___("blt.un.s") |
                ___("bne.un") |
                ___("bne.un.s") |
                _("br") |
                ___("br.s") |
                _("brfalse") |
                ___("brfalse.s") |
                _("brtrue") |
                ___("brtrue.s") |
                _("leave") |
                ___("leave.s");

            INSTR_METHOD.Rule =
                _("call") |
                _("callvirt") |
                _("jmp") |
                _("ldftn") |
                _("ldvirtftn") |
                _("newobj");

            INSTR_FIELD.Rule =
                _("ldfld") |
                _("ldflda") |
                _("ldsfld") |
                _("ldsflda") |
                _("stfld") |
                _("stsfld");

            INSTR_TYPE.Rule =
                _("box") |
                _("castclass") |
                _("cpobj") |
                _("initobj") |
                _("isinst") |
                _("ldelema") |
                _("ldobj") |
                _("mkrefany") |
                _("newarr") |
                _("refanyval") |
                _("sizeof") |
                _("stobj") |
                _("unbox") |
                ___("unbox.any"); // DOCS: non-present in ECMA grammar

            INSTR_STRING.Rule =
                _("ldstr");

            // TODO: INSTR_SIG
            INSTR_SIG.Rule = _("TODO: INSTR_SIG");

            // TODO: INSTR_RVA
            INSTR_RVA.Rule = _("TODO: INSTR_RVA");

            INSTR_SWITCH.Rule =
                _("switch");

            // TODO: INSTR_PHI
            INSTR_PHI.Rule = _("TODO: INSTR_PHI");

            INSTR_TOK.Rule =
                _("ldtoken");

            // rules

            Root = decls;

            decls.Rule =
                Empty |
                decls + decl;

            decl.Rule =
                classHead + _("{") + classDecls + _("}") |
                nameSpaceHead + _("{") + decls + _("}") |
                methodHead + methodDecls + _("}") |
                fieldDecl |
                dataDecl |
                vtableDecl |
                vtfixupDecl |
                extSourceSpec |
                fileDecl |
                assemblyHead + _("{") + assemblyDecls + _("}") |
                assemblyRefHead + _("{") + assemblyRefDecls + _("}") |
                comtypeHead + _("{") + comtypeDecls + _("}") |
                manifestResHead + _("{") + manifestResDecls + _("}") |
                moduleHead |
                secDecl |
                customAttrDecl |
                _(".subsystem") + int32 |
                _(".corflags") + int32 |
                _(".file") + _("alignment") + int32 |
                _(".imagebase") + int64 |
                languageDecl |
                _(".stackreserve") + int64; // DOCS: not present in ECMA grammar

            compQstring.Rule =
                QSTRING |
                compQstring + _("+") + QSTRING;

            // TODO: languageDecl
            languageDecl.Rule = _("TODO: languageDecl");

            customAttrDecl.Rule =
                _(".custom") + customType |
                _(".custom") + customType + _("=") + compQstring |
                customHead + bytes + _(")") |
                _(".custom") + _("(") + ownerType + _(")") + customType |
                _(".custom") + _("(") + ownerType + _(")") + customType + _("=") + compQstring |
                customHeadWithOwner + bytes + _(")");

            moduleHead.Rule =
                _(".module") |
                _(".module") + name1 |
                _(".module") + _("extern") + name1;

            // TODO: vtfixupDecl
            vtfixupDecl.Rule = _("TODO: vtfixupDecl");

            // TODO: vtableDecl
            vtableDecl.Rule = _("TODO: vtableDecl");

            // TODO: nameSpaceHead
            nameSpaceHead.Rule = _("TODO: nameSpaceHead");

            classHead.Rule =
                _(".class") + classAttr + id + extendsClause + implClause |
                _(".class") + classAttr + name1 + extendsClause + implClause; // DOCS: not present in ECMA grammar

            classAttr.Rule =
                Empty |
                classAttr + _("public") |
                classAttr + _("private") |
                classAttr + _("value") |
                classAttr + _("enum") |
                classAttr + _("interface") |
                classAttr + _("sealed") |
                classAttr + _("abstract") |
                classAttr + _("auto") |
                classAttr + _("sequential") |
                classAttr + _("explicit") |
                classAttr + _("ansi") |
                classAttr + _("unicode") |
                classAttr + _("autochar") |
                classAttr + _("import") |
                classAttr + _("serializable") |
                classAttr + _("nested") + _("public") |
                classAttr + _("nested") + _("private") |
                classAttr + _("nested") + _("family") |
                classAttr + _("nested") + _("assembly") |
                classAttr + _("nested") + _("famandassem") |
                classAttr + _("nested") + _("famorassem") |
                classAttr + _("beforefieldinit") |
                classAttr + _("specialname") |
                classAttr + _("rtspecialname");

            extendsClause.Rule =
                Empty |
                _("extends") + className;

            implClause.Rule =
                Empty |
                _("implements") + classNames;

            classNames.Rule =
                className + _(",") + className |
                className;

            classDecls.Rule =
                Empty |
                classDecls + classDecl;

            classDecl.Rule =
                methodHead + methodDecls + _("}") |
                classHead + _("{") + classDecls + _("}") |
                eventHead + _("{") + eventDecls + _("}") |
                propHead + _("{") + propDecls + _("}") |
                fieldDecl |
                dataDecl |
                secDecl |
                extSourceSpec |
                customAttrDecl |
                _(".size") + int32 |
                _(".pack") + int32 |
                exportHead + _("{") + comtypeDecls + _("}") |
                _(".override") + typeSpec + _("::") + methodName + _("with") + callConv + type + typeSpec + _("::") + methodName + _("(") + sigArgs0 + _(")") |
                languageDecl;

            fieldDecl.Rule =
                _(".field") + repeatOpt + fieldAttr + type + id + atOpt + initOpt;

            atOpt.Rule =
                Empty |
                _("at") + id;

            initOpt.Rule =
                Empty |
                _("=") + fieldInit;

            repeatOpt.Rule =
                Empty |
                _("[") + int32 + _("]");

            customHead.Rule =
                _(".custom") + customType + _("=") + _("(");

            customHeadWithOwner.Rule =
                _(".custom") + _("(") + ownerType + _(")") + customType + _("=") + _("(");

            memberRef.Rule =
                methodSpec + callConv + type + typeSpec + _("::") + methodName + _("(") + sigArgs0 + _(")") |
                methodSpec + callConv + type + methodName + _("(") + sigArgs0 + _(")") |
                _("field") + type + typeSpec + _("::") + id |
                _("field") + type + id;

            customType.Rule =
                callConv + type + typeSpec + _("::") + _(".ctor") + _("(") + sigArgs0 + _(")") |
                callConv + type + _(".ctor") + _("(") + sigArgs0 + _(")");

            ownerType.Rule =
                typeSpec |
                memberRef;

            // TODO: eventHead
            eventHead.Rule = _("TODO: eventHead");

            // TODO: eventDecls
            eventDecls.Rule = _("TODO: eventDecls");

            // TODO: propHead
            propHead.Rule = _("TODO: propHead");

            // TODO: propDecls
            propDecls.Rule = _("TODO: propDecls");

            methodHeadPart1.Rule =
                _(".method");

            methodHead.Rule =
                methodHeadPart1 + methAttr + callConv + paramAttr + type + methodName + _("(") + sigArgs0 + _(")") + implAttr + _("{") |
                methodHeadPart1 + methAttr + callConv + paramAttr + type + _("marshal") + _("(") + nativeType + _(")") + methodName + _("(") + sigArgs0 + _(")") + implAttr + _("{");

            methAttr.Rule =
                Empty |
                methAttr + _("static") |
                methAttr + _("public") |
                methAttr + _("private") |
                methAttr + _("family") |
                methAttr + _("final") |
                methAttr + _("specialname") |
                methAttr + _("virtual") |
                methAttr + _("abstract") |
                methAttr + _("assembly") |
                methAttr + _("famandassem") |
                methAttr + _("famorassem") |
                methAttr + _("privatescope") |
                methAttr + _("hidebysig") |
                methAttr + _("newslot") |
                methAttr + _("rtspecialname") |
                methAttr + _("unmanagedexp") |
                methAttr + _("reqsecobj") |
                methAttr + _("pinvokeimpl") + _("(") + compQstring + _("as") + compQstring + pinvAttr + _(")") |
                methAttr + _("pinvokeimpl") + _("(") + compQstring + pinvAttr + _(")") |
                methAttr + _("pinvokeimpl") + _("(") + pinvAttr + _(")");

            // TODO: pinvAttr
            pinvAttr.Rule = _("TODO: pinvAttr");

            methodName.Rule =
                _(".ctor") |
                _(".cctor") |
                name1;

            fieldAttr.Rule =
                Empty |
                fieldAttr + _("static") |
                fieldAttr + _("public") |
                fieldAttr + _("private") |
                fieldAttr + _("family") |
                fieldAttr + _("initonly") |
                fieldAttr + _("rtspecialname") |
                fieldAttr + _("specialname") |
                fieldAttr + _("pinvokeimpl") + _("(") + compQstring + _("as") + compQstring + pinvAttr + _(")") |
                fieldAttr + _("pinvokeimpl") + _("(") + compQstring + pinvAttr + _(")") |
                fieldAttr + _("pinvokeimpl") + _("(") + pinvAttr + _(")") |
                fieldAttr + _("marshal") + _("(") + nativeType + _(")") |
                fieldAttr + _("assembly") |
                fieldAttr + _("famandassem") |
                fieldAttr + _("famorassem") |
                fieldAttr + _("privatescope") |
                fieldAttr + _("literal") |
                fieldAttr + _("notserialized");

            paramAttr.Rule =
                Empty |
                paramAttr + _("[") + _("in") + _("]") |
                paramAttr + _("[") + _("out") + _("]") |
                paramAttr + _("[") + _("opt") + _("]") |
                paramAttr + _("[") + int32 + _("]");

            implAttr.Rule =
                Empty |
                implAttr + _("native") |
                implAttr + _("cil") |
                implAttr + _("optil") |
                implAttr + _("managed") |
                implAttr + _("unmanaged") |
                implAttr + _("forwardref") |
                implAttr + _("preservesig") |
                implAttr + _("runtime") |
                implAttr + _("internalcall") |
                implAttr + _("synchronized") |
                implAttr + _("noinlining");

            localsHead.Rule =
                _(".locals");

            methodDecl.Rule =
                _(".emitbyte") + int32 |
                sehBlock |
                _(".maxstack") + int32 |
                localsHead + _("(") + sigArgs0 + _(")") |
                localsHead + _("init") + _("(") + sigArgs0 + _(")") |
                _(".entrypoint") |
                _(".zeroinit") |
                dataDecl |
                instr |
                id + _(":") |
                secDecl |
                extSourceSpec |
                languageDecl |
                customAttrDecl |
                _(".export") + _("[") + int32 + _("]") |
                _(".export") + _("[") + int32 + _("]") + _("as") + id |
                _(".vtentry") + int32 + _(":") + int32 |
                _(".override") + typeSpec + _("::") + methodName |
                scopeBlock |
                _(".param") + _("[") + int32 + _("]") + initOpt;

            // TODO: scopeBlock
            scopeBlock.Rule = _("TODO: scopeBlock");

            // TODO: sehBlock
            sehBlock.Rule = _("TODO: sehBlock");

            methodDecls.Rule =
                Empty |
                methodDecls + methodDecl;

            dataDecl.Rule =
                ddHead + ddBody;

            ddHead.Rule =
                _(".data") + tls + id + _("=") |
                _(".data") + tls;

            tls.Rule =
                Empty |
                _("tls") |
                _("cil"); // DOCS: non-present in ECMA grammar

            ddBody.Rule =
                _("{") + ddItemList + _("}") |
                ddItem;

            ddItemList.Rule =
                ddItem + _(",") + ddItemList |
                ddItem;

            ddItemCount.Rule =
                Empty |
                _("[") + int32 + _("]");

            ddItem.Rule =
                _("char") + _("*") + _("(") + compQstring + _(")") |
                _("&") + _("(") + id + _(")") |
                bytearrayhead + bytes + _(")") |
                _("float32") + _("(") + float64 + _(")") + ddItemCount |
                _("float64") + _("(") + float64 + _(")") + ddItemCount |
                _("int64") + _("(") + int64 + _(")") + ddItemCount |
                _("int32") + _("(") + int32 + _(")") + ddItemCount |
                _("int16") + _("(") + int32 + _(")") + ddItemCount |
                _("int8") + _("(") + int32 + _(")") + ddItemCount |
                _("float32") + ddItemCount |
                _("float64") + ddItemCount |
                _("int64") + ddItemCount |
                _("int32") + ddItemCount |
                _("int16") + ddItemCount |
                _("int8") + ddItemCount;

            fieldInit.Rule =
                _("float32") + _("(") + float64 + _(")") |
                _("float64") + _("(") + float64 + _(")") |
                _("float32") + _("(") + int64 + _(")") |
                _("float64") + _("(") + int64 + _(")") |
                _("int64") + _("(") + int64 + _(")") |
                _("int32") + _("(") + int64 + _(")") |
                _("int16") + _("(") + int64 + _(")") |
                _("char") + _("(") + int64 + _(")") |
                _("int8") + _("(") + int64 + _(")") |
                _("uint8") + _("(") + int64 + _(")") | // DOCS: non-present in ECMA grammar
                _("bool") + _("(") + truefalse + _(")") |
                compQstring |
                bytearrayhead + bytes + _(")") |
                _("nullref");

            bytearrayhead.Rule =
                _("bytearray") + _("(");

            bytes.Rule =
                Empty |
                hexbytes;

            hexbytes.Rule =
                HEXBYTE |
                hexbytes + HEXBYTE;

            // TODO: instr_r_head
            instr_r_head.Rule = _("TODO: instr_r_head");

            instr_tok_head.Rule =
                INSTR_TOK;

            // TODO: methodSpec
            methodSpec.Rule = _("TODO: methodSpec");

            instr.Rule =
                INSTR_NONE |
                INSTR_VAR + int32 |
                INSTR_VAR + id |
                INSTR_I + int32 |
                INSTR_I8 + int64 |
                INSTR_R + float64 |
                INSTR_R + int64 |
                instr_r_head + bytes + _(")") |
                INSTR_BRTARGET + int32 |
                INSTR_BRTARGET + id |
                INSTR_METHOD + callConv + type + typeSpec + _("::") + methodName + _("(") + sigArgs0 + _(")") |
                INSTR_METHOD + callConv + type + methodName + _("(") + sigArgs0 + _(")") |
                INSTR_FIELD + type + typeSpec + _("::") + id |
                INSTR_FIELD + type + id |
                INSTR_TYPE + typeSpec |
                INSTR_STRING + compQstring |
                INSTR_STRING + bytearrayhead + bytes + _(")") |
                INSTR_SIG + callConv + type + _("(") + sigArgs0 + _(")") |
                INSTR_RVA + id |
                INSTR_RVA + int32 |
                instr_tok_head + ownerType |
                INSTR_SWITCH + _("(") + labels + _(")") |
                INSTR_PHI + int16s;

            sigArgs0.Rule =
                Empty |
                sigArgs1;

            sigArgs1.Rule =
                sigArg |
                sigArgs1 + _(",") + sigArg;

            sigArg.Rule =
                _("...") |
                paramAttr + type |
                paramAttr + type + id |
                paramAttr + type + _("marshal") + _("(") + nativeType + _(")") |
                paramAttr + type + _("marshal") + _("(") + nativeType + _(")") + id;

            name1.Rule =
                id |
                DOTTEDNAME |
                name1 + _(".") + name1;

            className.Rule =
                _("[") + name1 + _("]") + slashedName |
                _("[") + _(".module") + name1 + _("]") + slashedName |
                slashedName;

            slashedName.Rule =
                name1 |
                slashedName + _("/") + name1;

            typeSpec.Rule =
                className |
                _("[") + name1 + _("]") |
                _("[") + _(".module") + name1 + _("]") |
                type;

            callConv.Rule =
                _("instance") + callConv |
                _("explicit") + callConv |
                callKind;

            callKind.Rule =
                Empty |
                _("default") |
                _("vararg") |
                _("unmanaged") + _("cdecl") |
                _("unmanaged") + _("stdcall") |
                _("unmanaged") + _("thiscall") |
                _("unmanaged") + _("fastcall");

            // TODO: nativeType
            nativeType.Rule = _("TODO: nativeType");

            type.Rule =
                _("class") + className |
                _("object") |
                _("string") |
                _("value") + _("class") + className |
                _("valuetype") + className |
                type + _("[") + _("]") |
                type + ("[") + bounds1 + _("]") |
                type + _("value") + _("[") + int32 + _("]") | // TODO: check ECMA comment
                type + _("&") |
                type + _("*") |
                type + _("pinned") |
                type + _("modreq") + _("(") + className + _(")") |
                type + _("modopt") + _("(") + className + _(")") |
                _("!") + int32 |
                methodSpec + callConv + type + _("*") + _("(") + sigArgs0 + _(")") |
                _("typedref") |
                _("char") |
                _("void") |
                _("bool") |
                _("int8") |
                _("int16") |
                _("int32") |
                _("int64") |
                _("float32") |
                _("float64") |
                _("unsigned") + _("int8") |
                _("unsigned") + _("int16") |
                _("unsigned") + _("int32") |
                _("unsigned") + _("int64") |
                _("native") + _("int") |
                _("native") + _("unsigned") + _("int") |
                _("native") + _("float") |
                _("uint8") | // DOCS: not present in ECMA grammar
                _("uint16") | // DOCS: not present in ECMA grammar
                _("uint32") | // DOCS: not present in ECMA grammar
                _("uint64"); // DOCS: not present in ECMA grammar

            bounds1.Rule =
                bound |
                bounds1 + _(",") + bound;

            bound.Rule =
                Empty |
                _("...") |
                int32 |
                int32 + _("...") + int32 |
                int32 + _("...");

            labels.Rule =
                Empty |
                id + _(",") + labels |
                int32 + _(",") + labels |
                id |
                int32;

            id.Rule =
                ID |
                SQSTRING;

            // TODO: int16s
            int16s.Rule = _("TODO: int16s");

            int32.Rule =
                INT32; // TODO: ECMA grammar uses INT32 here

            int64.Rule =
                INT64;

            float64.Rule =
                FLOAT64 |
                _("float32") + _("(") + int32 + _(")") |
                _("float64") + _("(") + int64 + _(")");

            secDecl.Rule =
                _(".permission") + secAction + typeSpec + _("(") + nameValPairs + _(")") |
                _(".permission") + secAction + typeSpec |
                psetHead + bytes + _(")") |
                _(".permissionset") + secAction + _("=") + _("{") + nameValPairs + _("}"); // DOCS: non-present in ECMA script

            psetHead.Rule =
                _(".permissionset") + secAction + _("=") + _("(");

            nameValPairs.Rule =
                nameValPair |
                nameValPair + _(",") + nameValPairs;

            nameValPair.Rule =
                compQstring + _("=") + caValue |
                className + _("=") + caValue; // DOCS: non-present in ECMA script

            truefalse.Rule =
                _("true") |
                _("false");

            caValue.Rule =
                truefalse |
                int32 |
                _("int32") + ("(") + int32 + _(")") |
                compQstring |
                className + _("(") + _("int8") + _(":") + int32 + _(")") |
                className + _("(") + _("int16") + _(":") + int32 + _(")") |
                className + _("(") + _("int32") + _(":") + int32 + _(")") |
                className + _("(") + int32 + _(")") |
                _("{") + _("property") + _("bool") + SQSTRING + _("=") + _("bool") + _("(") + _("true") + _(")") + _("}"); // DOCS: non-present in ECMA script

            secAction.Rule =
                _("request") |
                _("demand") |
                _("assert") |
                _("deny") |
                _("permitonly") |
                _("linkcheck") |
                _("inheritcheck") |
                _("reqmin") |
                _("reqopt") |
                _("reqrefuse") |
                _("prejitgrant") |
                _("prejitdeny") |
                _("noncasdemand") |
                _("noncaslinkdemand") |
                _("noncasinheritance");

            // TODO: extSourceSpec
            extSourceSpec.Rule = _("TODO: extSourceSpec");

            // TODO: fileDecl
            fileDecl.Rule = _("TODO: fileDecl");

            // TODO: hashHead
            hashHead.Rule = _("TODO: hashHead");

            assemblyHead.Rule =
                _(".assembly") + asmAttr + name1;

            asmAttr.Rule =
                Empty |
                asmAttr + _("noappdomain") |
                asmAttr + _("noprocess") |
                asmAttr + _("nomachine");

            assemblyDecls.Rule =
                Empty |
                assemblyDecls + assemblyDecl;

            assemblyDecl.Rule =
                _(".hash") + _("algorithm") + int32 |
                secDecl |
                asmOrRefDecl;

            asmOrRefDecl.Rule =
                publicKeyHead + bytes + _(")") |
                _(".ver") + int32 + _(":") + int32 + _(":") + int32 + _(":") + int32 |
                _(".locale") + compQstring |
                localeHead + bytes + _(")") |
                customAttrDecl;

            // TODO: publicKeyHead
            publicKeyHead.Rule = _("TODO: publicKeyHead");

            publicKeyTokenHead.Rule =
                _(".publickeytoken") + _("=") + _("(");

            // TODO: localeHead
            localeHead.Rule = _("TODO: localeHead");

            assemblyRefHead.Rule =
                _(".assembly") + _("extern") + name1 |
                _(".assembly") + _("extern") + name1 + _("as") + name1;

            assemblyRefDecls.Rule =
                Empty |
                assemblyRefDecls + assemblyRefDecl;

            assemblyRefDecl.Rule =
                hashHead + bytes + _(")") |
                asmOrRefDecl |
                publicKeyTokenHead + bytes + _(")");

            // TODO: comtypeHead
            comtypeHead.Rule = _("TODO: comtypeHead");

            // TODO: exportHead
            exportHead.Rule = _("TODO: exportHead");

            // TODO: comtypeDecls
            comtypeDecls.Rule = _("TODO: comtypeDecls");

            manifestResHead.Rule =
                _(".mresource") + manresAttr + name1;

            manresAttr.Rule =
                Empty |
                manresAttr + _("public") |
                manresAttr + _("private");

            manifestResDecls.Rule =
                Empty |
                manifestResDecls + manifestResDecl;

            manifestResDecl.Rule =
                _(".file") + name1 + _("at") + int32 |
                _(".assembly") + _("extern") + name1 |
                customAttrDecl;
        }

        private KeyTerm _(string s)
        {
            if (!CheckIf_CanBeUsed(s)) throw new ArgumentException($"Cannot use _ method with string \"{s}\".");

            return ToTerm(s);
        }

        private NonTerminal ___(string s)
        {
            if (!CheckIf___CanBeUsed(s)) throw new ArgumentException($"Cannot use ___ method with string \"{s}\".");

            var splittedToken = Regex.Split(s, @"(\.)").Where(st => !string.IsNullOrEmpty(st)).ToList();

            if (s.All(c => !char.IsLetterOrDigit(c))) splittedToken = s.Select(c => c.ToString()).ToList();

            var result = new NonTerminal(s);

            result.Rule = ToTerm(splittedToken[0]);
            foreach (var tokenPart in splittedToken.Skip(1))
            {
                result.Rule += ToTerm(tokenPart);
            }

            result.SetFlag(TermFlags.NoAstNode);

            return result;
        }

        private static NonTerminal CreateNonTerminal(string name)
        {
            var result = new NonTerminal(name);
            result.AstConfig = new AstNodeConfig
            {
                NodeType = GetNodeType(name)
            };
            return result;
        }

        private static Type GetNodeType(string termName)
        {
            return AstNodeTypeFactory.CreateAstNodeType(termName);
        }

        private static void ConfigureAstNode(BnfTerm bnfTerm)
        {
            bnfTerm.AstConfig = new AstNodeConfig
            {
                NodeType = GetNodeType(bnfTerm.Name)
            };
        }
        
        private bool CheckIf_CanBeUsed(string s)
        {
            return !CheckIf___CanBeUsed(s);
        }

        private bool CheckIf___CanBeUsed(string s)
        {
            return s.IndexOf('.') > 0 && s.IndexOf('.') < s.Length - 1;
        }
    }
}