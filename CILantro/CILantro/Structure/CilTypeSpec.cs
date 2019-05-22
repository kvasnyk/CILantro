using CILantro.Interpreting.Types;
using System;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilTypeSpec
    {
        public CilClassName ClassName { get; set; }

        public CilType GetCilType(CilProgram _program)
        {
            if (!_program.IsExternalType(this) && ClassName != null)
            {
                return new CilTypeClass(ClassName);
            }

            if (_program.IsExternalType(this) && ClassName != null)
            {
                var assembly = Assembly.Load(ClassName.AssemblyName);
                var type = assembly.GetType(ClassName.ClassName);

                if (type == typeof(char))
                    return new CilTypeChar();
                if (type == typeof(string))
                    return new CilTypeString();
                if (type == typeof(int))
                    return new CilTypeInt32();
                if (type == typeof(sbyte))
                    return new CilTypeInt8();
                if (type == typeof(ushort))
                    return new CilTypeUInt16();
                if (type == typeof(ulong))
                    return new CilTypeUInt64();
                if (type == typeof(uint))
                    return new CilTypeUInt32();
                if (type == typeof(short))
                    return new CilTypeInt16();
                if (type == typeof(long))
                    return new CilTypeInt64();
                if (type == typeof(float))
                    return new CilTypeFloat32();
                if (type == typeof(double))
                    return new CilTypeFloat64();
                if (type == typeof(byte))
                    return new CilTypeUInt8();
                if (type == typeof(object))
                    return new CilTypeObject();
                else if (type.IsValueType)
                    return new CilTypeValueType(ClassName);
                else
                    return new CilTypeClass(ClassName);
            }

            throw new NotImplementedException();
        }
    }
}