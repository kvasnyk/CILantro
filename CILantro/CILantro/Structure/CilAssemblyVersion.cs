namespace CILantro.Structure
{
    public class CilAssemblyVersion
    {
        public int V1 { get; set; }

        public int V2 { get; set; }

        public int V3 { get; set; }

        public int V4 { get; set; }

        public override string ToString()
        {
            return $"{V1}:{V2}:{V3}:{V4}";
        }
    }
}