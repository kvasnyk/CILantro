﻿namespace CILantro.Instructions.None
{
    public class ConvertUInstruction : CilInstructionNone
    {
        public override bool IsSupported => false;

        public override string ToString()
        {
            return "conv.u";
        }
    }
}