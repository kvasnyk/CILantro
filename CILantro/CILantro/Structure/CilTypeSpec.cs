﻿using CILantro.Interpreting.Types;
using System;
using System.Reflection;

namespace CILantro.Structure
{
    public class CilTypeSpec
    {
        public CilClassName ClassName { get; set; }

        public CilType GetCilType()
        {
            if (ClassName != null)
            {
                var assembly = Assembly.Load(ClassName.AssemblyName);
                var type = assembly.GetType(ClassName.ClassName);

                if (type == typeof(char))
                    return new CilTypeChar();
                if (type == typeof(string))
                    return new CilTypeString();
                else
                    throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}