﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.StackObjects;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeVoid : CilType
    {
        public override IStackObject CreateInstanceFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new ArgumentException("Cannot create an instance of type void.");
        }

        public override Type GetRuntimeType()
        {
            throw new NotImplementedException();
        }
    }
}