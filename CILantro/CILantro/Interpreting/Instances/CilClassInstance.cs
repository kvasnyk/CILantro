using CILantro.Interpreting.Memory;
using CILantro.Interpreting.Objects;
using CILantro.Interpreting.Types;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CILantro.Interpreting.Instances
{
    public class CilClassInstance : CilObject
    {
        public CilClass Class { get; private set; }

        public Dictionary<string, IValue> Fields { get; }

        private object _externalInstance;

        public CilClassInstance(CilClass @class, CilProgram program)
        {
            Class = @class;

            Fields = new Dictionary<string, IValue>();
            foreach (var field in @class.Fields.Where(f => !f.IsStatic))
            {
                Fields.Add(field.Name, field.Type.CreateDefaultValue(program));
            }

            var parentClass = Class;
            while (!program.IsExternalType(parentClass.ExtendsName))
                parentClass = parentClass.Extends;

            var extProxy = RuntimeTypeBuilder.RegisterType(parentClass.ExtendsName);
            _externalInstance = FormatterServices.GetUninitializedObject(extProxy);
        }

        public override object AsRuntime(CilType type, CilManagedMemory managedMemory)
        {
            return _externalInstance;
        }
    }
}