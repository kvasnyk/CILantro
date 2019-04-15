﻿using CILantro.Instructions;
using System.Collections.Generic;

namespace CILantro.Structure
{
    public class CilMethod
    {
        public string Name { get; set; }

        public bool IsEntryPoint { get; set; }

        public List<CilInstruction> Instructions { get; set; }

        public List<CilSigArg> Locals { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}