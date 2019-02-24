namespace CILantro.Model
{
    public class CilSigArg
    {
        public CilType Type { get; set; }

        public CilSigArg(CilType type)
        {
            Type = type;
        }
    }
}