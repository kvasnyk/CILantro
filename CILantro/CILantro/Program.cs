using CILantro.Engine;

namespace CILantro
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new CilEngine("test");
            engine.Parse();
        }
    }
}