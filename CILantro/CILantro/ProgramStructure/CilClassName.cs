namespace CILantro.ProgramStructure
{
    public class CilClassName
    {
        public string ClassName { get; }

        public string AssemblyName { get; }

        public CilClassName(string className, string assemblyName)
        {
            ClassName = className;
            AssemblyName = assemblyName;
        }

        public override string ToString()
        {
            return $"[{AssemblyName}]{ClassName}";
        }
    }
}