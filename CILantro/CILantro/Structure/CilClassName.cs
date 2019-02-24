namespace CILantro.Structure
{
    public class CilClassName
    {
        public string ClassName { get; set; }

        public string AssemblyName { get; set; }

        public override string ToString()
        {
            return $"[{AssemblyName}]{ClassName}";
        }
    }
}