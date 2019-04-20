﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeUInt16 : CilType
    {
        public override Type GetRuntimeType()
        {
            return typeof(ushort);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueUInt16);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueUInt16((ushort)obj);
            return value;
        }
    }
}