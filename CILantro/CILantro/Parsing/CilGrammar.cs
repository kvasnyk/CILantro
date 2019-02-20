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
            DOTTEDNAME.Rule = Empty;

            // TODO: specify
            var ID = new IdentifierTerminal("ID");

            // TODO: specify
            var SQSTRING = new NonTerminal("SQSTRING");
            SQSTRING.Rule = Empty;

            // TODO: specify
            var INT32 = new NumberLiteral("INT32", NumberOptions.IntOnly);

            // TODO: specify
            var INT64 = new NumberLiteral("INT64", NumberOptions.IntOnly);

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
            var classDecls = new NonTerminal("classDecls");
            var fieldDecl = new NonTerminal("fieldDecl");
            var customHead = new NonTerminal("customHead");
            var customHeadWithOwner = new NonTerminal("customHeadWithOwner");
            var customType = new NonTerminal("customType");
            var ownerType = new NonTerminal("ownerType");
            var methodHead = new NonTerminal("methodHead");
            var methodDecls = new NonTerminal("methodDecls");
            var dataDecl = new NonTerminal("dataDecl");
            var bytes = new NonTerminal("bytes");
            var hexbytes = new NonTerminal("hexbytes");
            var sigArgs0 = new NonTerminal("sigArgs0");
            var name1 = new NonTerminal("name1");
            var typeSpec = new NonTerminal("typeSpec");
            var callConv = new NonTerminal("callConv");
            var callKind = new NonTerminal("callKind");
            var type = new NonTerminal("type");
            var id = new NonTerminal("id");
            var int32 = new NonTerminal("int32");
            var int64 = new NonTerminal("int64");
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
            var comtypeDecls = new NonTerminal("comtypeDecls");
            var manifestResHead = new NonTerminal("manifestResHead");
            var manifestResDecls = new NonTerminal("manifestResDecls");

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
                languageDecl;

            // TODO: rule
            compQstring.Rule = Empty;

            // TODO: rule
            languageDecl.Rule = Empty;

            customAttrDecl.Rule =
                _(".custom") + customType |
                _(".custom") + customType + _("=") + compQstring |
                customHead + bytes + _(")") |
                _(".custom") + _("(") + ownerType + _(")") + customType |
                _(".custom") + _("(") + ownerType + _(")") + customType + _("=") + compQstring |
                customHeadWithOwner + bytes + _(")");

            // TODO: rule
            moduleHead.Rule = Empty;

            // TODO: rule
            vtfixupDecl.Rule = Empty;

            // TODO: rule
            vtableDecl.Rule = Empty;

            // TODO: rule
            nameSpaceHead.Rule = Empty;

            // TODO: rule
            classHead.Rule = Empty;

            // TODO: rule
            classDecls.Rule = Empty;

            // TODO: rule
            fieldDecl.Rule = Empty;

            // TODO: rule
            customHead.Rule = Empty;

            // TODO: rule
            customHeadWithOwner.Rule = Empty;

            customType.Rule =
                callConv + type + typeSpec + _("::") + _(".ctor") + _("(") + sigArgs0 + _(")") |
                callConv + type + _(".ctor") + _("(") + sigArgs0 + _(")");

            // TODO: rule
            ownerType.Rule = Empty;

            // TODO: rule
            methodHead.Rule = Empty;

            // TODO: rule
            methodDecls.Rule = Empty;

            // TODO: rule
            dataDecl.Rule = Empty;

            bytes.Rule =
                Empty |
                hexbytes;

            hexbytes.Rule =
                HEXBYTE |
                hexbytes + HEXBYTE;

            // TODO: rule
            sigArgs0.Rule = Empty;

            name1.Rule =
                id |
                DOTTEDNAME |
                name1 + _(".") + name1;

            // TODO: rule
            typeSpec.Rule = Empty;

            callConv.Rule =
                _("instance") + callConv |
                _("explicit") + callConv |
                callKind;

            // TODO: rule
            callKind.Rule = Empty;

            // TODO: rule
            type.Rule = Empty;

            id.Rule =
                ID |
                SQSTRING;

            int32.Rule =
                INT64; // TODO: perhaps INT32?

            // TODO: rule
            int64.Rule = Empty;

            // TODO: rule
            secDecl.Rule = Empty;

            // TODO: rule
            extSourceSpec.Rule = Empty;

            // TODO: rule
            fileDecl.Rule = Empty;

            // TODO: rule
            hashHead.Rule = Empty;

            assemblyHead.Rule =
                _(".assembly") + asmAttr + name1;

            // TODO: rule
            asmAttr.Rule = Empty;

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

            // TODO: rule
            publicKeyHead.Rule = Empty;

            publicKeyTokenHead.Rule =
                _(".publickeytoken") + _("=") + _("(");

            // TODO: rule
            localeHead.Rule = Empty;

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

            // TODO: rule
            comtypeHead.Rule = Empty;

            // TODO: rule
            comtypeDecls.Rule = Empty;

            // TODO: rule
            manifestResHead.Rule = Empty;

            // TODO: rule
            manifestResDecls.Rule = Empty;
        }

        private KeyTerm _(string s)
        {
            return ToTerm(s);
        }
    }
}