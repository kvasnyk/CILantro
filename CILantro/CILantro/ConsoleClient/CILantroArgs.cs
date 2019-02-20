using CommandLineParser.Arguments;

namespace CILantro.ConsoleClient
{
    public class CILantroArgs
    {
        [ValueArgument(typeof(string), 'f', "fileName", AllowMultiple = false)]
        public string FileName { get; set; }

        public static CILantroArgs Parse(string[] args)
        {
            var result = new CILantroArgs();
            var parser = new CommandLineParser.CommandLineParser();
            parser.ExtractArgumentAttributes(result);
            parser.ParseCommandLine(args);
            return result;
        }
    }
}