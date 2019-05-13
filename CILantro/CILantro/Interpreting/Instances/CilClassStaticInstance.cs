using CILantro.Interpreting.Values;
using CILantro.Structure;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.Instances
{
    public class CilClassStaticInstance
    {
        private CilClass Class { get; set; }

        public Dictionary<string, IValue> StaticFields { get; set; }

        public CilClassStaticInstance(CilClass @class, CilProgram program)
        {
            Class = @class;

            StaticFields = new Dictionary<string, IValue>();
            foreach (var field in @class.Fields.Where(f => f.IsStatic))
            {
                StaticFields.Add(field.Name, field.Type.CreateDefaultValue(program));
            }
        }
    }
}