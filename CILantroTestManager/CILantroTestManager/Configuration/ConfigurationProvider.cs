using System.Configuration;

namespace CILantroTestManager.Configuration
{
    public static class ConfigurationProvider
    {
        public static string TestsDirectoryPath => ConfigurationManager.AppSettings["TestsDirectoryPath"];

        public static string TestsDataDirectoryPath => ConfigurationManager.AppSettings["TestsDataDirectoryPath"];

        public static string IlasmPath => ConfigurationManager.AppSettings["IlasmPath"];

        public static string IldasmPath => ConfigurationManager.AppSettings["IldasmPath"];
    }
}