using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.Instances
{
    public class CilClassInstance : CilObject
    {
        public CilClass Class { get; private set; }

        public Dictionary<string, IValue> Fields { get; }

        public CilClassInstance(CilClass @class, CilProgram program)
        {
            Class = @class;

            Fields = new Dictionary<string, IValue>();
            foreach (var field in @class.Fields.Where(f => !f.IsStatic))
            {
                Fields.Add(field.Name, field.Type.CreateDefaultValue(program));
            }
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            if (type is CilTypeObject)
                return this;

            throw new System.NotImplementedException();
        }
    }
}