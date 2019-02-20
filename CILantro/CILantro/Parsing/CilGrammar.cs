using Irony.Parsing;

namespace CILantro.Parsing
{
    public class CilGrammar : Grammar
    {
        public CilGrammar()
            : base(true)
        {
            // comments

            var SINGLELINECOMMENT = new CommentTerminal("SINGLELINECOMMENT", "//", "\n", "\r\n");

            NonGrammarTerminals.Add(SINGLELINECOMMENT);

            // lexical tokens

            // TODO: specify
            var HEXBYTE = new RegexBasedTerminal("HEXBYTE", @"[A-F0-9]{2}");

            // TODO: specify
            var DOTTEDNAME = new NonTerminal("DOTTEDNAME");
            DOTTEDNAME.Rule = _("DOTTEDNAME");

            // TODO: specify
            var ID = new IdentifierTerminal("ID");

            // TODO: specify
            var QSTRING = new StringLiteral("QSTRING", "\"");

            // TODO: specify
            var SQSTRING = new StringLiteral("SQSTRING", "'");

            // TODO: specify
            var INT32 = new RegexBasedTerminal("INT32", @"(0x)?[0-9]*");

            // TODO: specify
            var INT64 = new RegexBasedTerminal("INT64", @"(0x)?[0-9]*");

            // non-terminals

            var decls = new NonTerminal("decls");
            var decl = new NonTerminal("decl");
            var compQstring = new NonTerminal("compQstring");
            var languageDecl = new NonTerminal("languageDecl");
            var customAttrDecl = new NonTerminal("customAttrDecl");
            var moduleHead = new NonTerminal("moduleHead");
            var vtfixupDecl = new NonTerminal("vtfixupDecl");
            var vtableDecl = new NonTerminal("vtableDecl");
            var nameSpaceHead = new NonTerminal("nameSpaceHead");
            var classHead = new NonTerminal("classHead");
            var classAttr = new NonTerminal("classAttr");
            var extendsClause = new NonTerminal("extendsClause");
            var implClause = new NonTerminal("implClause");
            var classNames = new NonTerminal("classNames");
            var classDecls = new NonTerminal("classDecls");
            var classDecl = new NonTerminal("classDecl");
            var fieldDecl = new NonTerminal("fieldDecl");
            var initOpt = new NonTerminal("initOpt");
            var customHead = new NonTerminal("customHead");
            var customHeadWithOwner = new NonTerminal("customHeadWithOwner");
            var customType = new NonTerminal("customType");
            var ownerType = new NonTerminal("ownerType");
            var eventHead = new NonTerminal("eventHead");
            var eventDecls = new NonTerminal("eventDecls");
            var propHead = new NonTerminal("propHead");
            var propDecls = new NonTerminal("propDecls");
            var methodHeadPart1 = new NonTerminal("methodHeadPart1");
            var methodHead = new NonTerminal("methodHead");
            var methAttr = new NonTerminal("methAttr");
            var pinvAttr = new NonTerminal("pinvAttr");
            var methodName = new NonTerminal("methodName");
            var paramAttr = new NonTerminal("paramAttr");
            var implAttr = new NonTerminal("implAttr");
            var localsHead = new NonTerminal("localsHead");
            var methodDecl = new NonTerminal("methodDecl");
            var scopeBlock = new NonTerminal("scopeBlock");
            var sehBlock = new NonTerminal("sehBlock");
            var methodDecls = new NonTerminal("methodDecls");
            var dataDecl = new NonTerminal("dataDecl");
            var bytearrayhead = new NonTerminal("bytearrayhead");
            var bytes = new NonTerminal("bytes");
            var hexbytes = new NonTerminal("hexbytes");
            var instr_r_head = new NonTerminal("instr_r_head");
            var instr_tok_head = new NonTerminal("instr_tok_head");
            var methodSpec = new NonTerminal("methodSpec");
            var instr = new NonTerminal("instr");
            var sigArgs0 = new NonTerminal("sigArgs0");
            var sigArgs1 = new NonTerminal("sigArgs1");
            var sigArg = new NonTerminal("sigArg");
            var name1 = new NonTerminal("name1");
            var className = new NonTerminal("className");
            var slashedName = new NonTerminal("slashedName");
            var typeSpec = new NonTerminal("typeSpec");
            var callConv = new NonTerminal("callConv");
            var callKind = new NonTerminal("callKind");
            var nativeType = new NonTerminal("nativeType");
            var type = new NonTerminal("type");
            var bounds1 = new NonTerminal("bounds1");
            var labels = new NonTerminal("labels");
            var id = new NonTerminal("id");
            var int16s = new NonTerminal("int16s");
            var int32 = new NonTerminal("int32");
            var int64 = new NonTerminal("int64");
            var float64 = new NonTerminal("float64");
            var secDecl = new NonTerminal("secDecl");
            var extSourceSpec = new NonTerminal("extSourceSpec");
            var fileDecl = new NonTerminal("fileDecl");
            var hashHead = new NonTerminal("hashHead");
            var assemblyHead = new NonTerminal("assemblyHead");
            var asmAttr = new NonTerminal("asmAttr");
            var assemblyDecls = new NonTerminal("assemblyDecls");
            var assemblyDecl = new NonTerminal("assemblyDecl");
            var asmOrRefDecl = new NonTerminal("asmOrRefDecl");
            var publicKeyHead = new NonTerminal("publicKeyHead");
            var publicKeyTokenHead = new NonTerminal("publicKeyTokenHead");
            var localeHead = new NonTerminal("localeHead");
            var assemblyRefHead = new NonTerminal("assemblyRefHead");
            var assemblyRefDecls = new NonTerminal("assemblyRefDecls");
            var assemblyRefDecl = new NonTerminal("assemblyRefDecl");
            var comtypeHead = new NonTerminal("comtypeHead");
            var exportHead = new NonTerminal("exportHead");
            var comtypeDecls = new NonTerminal("comtypeDecls");
            var manifestResHead = new NonTerminal("manifestResHead");
            var manifestResDecls = new NonTerminal("manifestResDecls");

            // instructions

            var INSTR_NONE = new NonTerminal("INSTR_NONE");
            var INSTR_VAR = new NonTerminal("INSTR_VAR");
            var INSTR_I = new NonTerminal("INSTR_I");
            var INSTR_I8 = new NonTerminal("INSTR_I8");
            var INSTR_R = new NonTerminal("INSTR_R");
            var INSTR_BRTARGET = new NonTerminal("INSTR_BRTARGET");
            var INSTR_METHOD = new NonTerminal("INSTR_METHOD");
            var INSTR_FIELD = new NonTerminal("INSTR_FIELD");
            var INSTR_TYPE = new NonTerminal("INSTR_TYPE");
            var INSTR_STRING = new NonTerminal("INSTR_STRING");
            var INSTR_SIG = new NonTerminal("INSTR_SIG");
            var INSTR_RVA = new NonTerminal("INSTR_RVA");
            var INSTR_SWITCH = new NonTerminal("INSTR_SWITCH");
            var INSTR_PHI = new NonTerminal("INSTR_PHI");

            // TODO: INSTR_NONE
            INSTR_NONE.Rule = _("TODO: INSTR_NONE");

            // TODO: INSTR_VAR
            INSTR_VAR.Rule = _("TODO: INSTR_VAR");

            // TODO: INSTR_I
            INSTR_I.Rule = _("TODO: INSTR_I");

            // TODO: INSTR_I8
            INSTR_I8.Rule = _("TODO: INSTR_I8");

            // TODO: INSTR_R
            INSTR_R.Rule = _("TODO: INSTR_R");

            // TODO: INSTR_BRTARGET
            INSTR_BRTARGET.Rule = _("TODO: INSTR_BRTARGET");

            INSTR_METHOD.Rule =
                _("call") |
                _("callvirt") |
                _("jmp") |
                _("ldftn") |
                _("ldvirtftn") |
                _("newobj");

            // TODO: INSTR_FIELD
            INSTR_FIELD.Rule = _("TODO: INSTR_FIELD");

            // TODO: INSTR_TYPE
            INSTR_TYPE.Rule = _("TODO: INSTR_TYPE");

            INSTR_STRING.Rule =
                _("ldstr");

            // TODO: INSTR_SIG
            INSTR_SIG.Rule = _("TODO: INSTR_SIG");

            // TODO: INSTR_RVA
            INSTR_RVA.Rule = _("TODO: INSTR_RVA");

            // TODO: INSTR_SWITCH
            INSTR_SWITCH.Rule = _("TODO: INSTR_SWITCH");

            // TODO: INSTR_PHI
            INSTR_PHI.Rule = _("TODO: INSTR_PHI");

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

            // TODO: classNames
            classNames.Rule = _("TODO: classNames");

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

            // TODO: fieldDecl
            fieldDecl.Rule = _("TODO: fieldDecl");

            // TODO: initOpt
            initOpt.Rule = _("TODO: initOpt");

            customHead.Rule =
                _(".custom") + customType + _("=") + _("(");

            customHeadWithOwner.Rule =
                _(".custom") + _("(") + ownerType + _(")") + customType + _("=") + _("(");

            customType.Rule =
                callConv + type + typeSpec + _("::") + _(".ctor") + _("(") + sigArgs0 + _(")") |
                callConv + type + _(".ctor") + _("(") + sigArgs0 + _(")");

            // TODO: ownerType
            ownerType.Rule = _("TODO: ownerType");

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

            // TODO: dataDecl
            dataDecl.Rule = _("TODO: dataDecl");

            // TODO: bytearrayhead
            bytearrayhead.Rule = _("TODO: bytearrayhead");

            bytes.Rule =
                Empty |
                hexbytes;

            hexbytes.Rule =
                HEXBYTE |
                hexbytes + HEXBYTE;

            // TODO: instr_r_head
            instr_r_head.Rule = _("TODO: instr_r_head");

            // TODO: instr_tok_head
            instr_tok_head.Rule = _("TODO: instr_tok_head");

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
                instr_tok_head + ownerType | // TODO: check comment in ECMA grammar
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
                _("native") + _("float");

            // TODO: bounds1
            bounds1.Rule = _("TODO: bounds1");

            // TODO: labels
            labels.Rule = _("TODO: labels");

            id.Rule =
                ID |
                SQSTRING;

            // TODO: int16s
            int16s.Rule = _("TODO: int16s");

            int32.Rule =
                INT64; // TODO: perhaps INT32?

            int64.Rule =
                INT64;

            // TODO: float64
            float64.Rule = _("TODO: float64");

            // TODO: secDecl
            secDecl.Rule = _("TODO: secDecl");

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

            // TODO: manifestResHead
            manifestResHead.Rule = _("TODO: manifestResHead");

            // TODO: manifestResDecls
            manifestResDecls.Rule = _("TODO: manifestResDecls");
        }

        private KeyTerm _(string s)
        {
            return ToTerm(s);
        }
    }
}