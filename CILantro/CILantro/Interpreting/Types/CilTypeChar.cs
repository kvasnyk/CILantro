﻿using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System;

namespace CILantro.Interpreting.Types
{
    public class CilTypeChar : CilType
    {
        public override bool IsValueType(CilProgram program)
        {
            return true;
        }

        public override bool IsNullable => false;

        public override Type GetRuntimeType(CilProgram program)
        {
            return typeof(char);
        }

        public override Type GetValueType(CilProgram program)
        {
            return typeof(CilValueChar);
        }

        public override IValue CreateValueFromRuntime(object obj, CilManagedMemory managedMemory, CilProgram program)
        {
            var value = new CilValueChar((char)obj);
            return value;
        }

        public override IValue CreateDefaultValue(CilProgram program)
        {
            return new CilValueChar(default(char));
        }

        public override bool IsAssignableFrom(CilType other)
        {
            if (other is CilTypeChar)
                return true;

            return false;
        }

        public override IValue Unbox(CilObject obj, CilManagedMemory managedMemory, CilProgram program)
        {
            throw new NotImplementedException();
        }
    }
}