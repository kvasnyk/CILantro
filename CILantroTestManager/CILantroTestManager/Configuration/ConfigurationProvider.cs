using System.Configuration;

namespace CILantroTestManager.Configuration
{
    public static class ConfigurationProvider
    {
        public static string TestsDirectoryPath => ConfigurationManager.AppSettings["TestsDirectoryPath"];

        public static string TestFileNamePattern => ConfigurationManager.AppSettings["TestFileNamePattern"];
    }
}