using CILantro.Interpreting.Values;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Structure
{
    public class CilData
    {
        public List<CilDataItem> Items { get; set; }

        public IValue GetValue()
        {
            if (Items.Count == 1)
            {
                return Items.First().GetValue();
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}