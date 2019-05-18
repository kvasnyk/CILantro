using CILantro.Instructions;
using CILantro.Interpreting.Types;
using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilMethod
    {
        public string Name { get; set; }

        public bool IsEntryPoint { get; set; }

        public bool IsConstructor => Name == ".ctor";

        public List<CilInstruction> Instructions { get; set; }

        public CilCallConv CallConv { get; set; }

        public List<CilSigArg> Locals { get; set; }

        public List<CilSigArg> Arguments { get; set; }

        public CilType ReturnType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}