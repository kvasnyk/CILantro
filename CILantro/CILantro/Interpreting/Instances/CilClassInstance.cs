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
        private readonly CilClass _class;

        public Dictionary<string, IValue> Fields { get; }

        public CilClassInstance(CilClass @class, CilProgram program)
        {
            _class = @class;

            Fields = new Dictionary<string, IValue>();
            foreach (var field in @class.Fields.Where(f => !f.IsStatic))
            {
                Fields.Add(field.Name, field.Type.CreateDefaultValue(program));
            }
        }

        public override object AsRuntime(CilType type)
        {
            throw new System.NotImplementedException();
        }
    }
}