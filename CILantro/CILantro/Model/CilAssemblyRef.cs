namespace CILantro.Model
{
    public class CilAssemblyRef
    {
        public string Name { get; set; }

        public CilAssemblyVersion Version { get; set; }

        public byte[] PublicKeyToken { get; set; }
    }
}