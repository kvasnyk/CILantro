namespace CILantro.Model
{
    public class CilAssemblyVersion
    {
        public int V1 { get; }

        public int V2 { get; }

        public int V3 { get; }

        public int V4 { get; }

        public CilAssemblyVersion(int v1, int v2, int v3, int v4)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
        }

        public override string ToString()
        {
            return $"{nameof(CilAssemblyVersion)}-{V1}:{V2}:{V3}:{V4}";
        }
    }
}