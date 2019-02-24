namespace CILantro.PorgramStructure
{
    public class CilTypeSpec
    {
        public CilClassName ClassName { get; set; }

        public CilTypeSpec(CilClassName className)
        {
            ClassName = className;
        }
    }
}