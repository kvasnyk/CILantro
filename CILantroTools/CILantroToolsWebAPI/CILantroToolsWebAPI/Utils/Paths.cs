using CILantroToolsWebAPI.Settings;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace CILantroToolsWebAPI.Utils
{
    public class Paths
    {
        private readonly AppSettings _appSettings;

        public string Ilasm => _appSettings.IlasmExePath;

        public string Ildasm => _appSettings.IldasmExePath;

        public string CilAntro => _appSettings.CILantroExePath;

        public TestsPaths Tests => new TestsPaths(_appSettings.TestsDirectoryPath);

        public TestsDataPaths TestsData => new TestsDataPaths(_appSettings.TestsDataDirectoryPath);

        public RunsDataPaths RunsData => new RunsDataPaths(_appSettings.RunsDataDirectoryPath);

        public Paths(IOptions<AppSettings> appSettingsOptions)
        {
            _appSettings = appSettingsOptions.Value;
        }
    }

    public class CilAntroPath
    {
        public string Absolute { get; }

        public string Relative { get; }

        public CilAntroPath(string basePath, string restPath = null)
        {
            if (string.IsNullOrEmpty(restPath))
                restPath = "";

            var fullPath = Path.Combine(basePath, restPath);

            Relative = Path.Combine("\\", restPath);
            Absolute = fullPath;

            EnsureDirectoryExists();
        }

        public CilAntroPath(CilAntroPath basePath, string restPath)
        {
            if (string.IsNullOrEmpty(restPath))
                restPath = "";

            Absolute = Path.Combine(basePath.Absolute, restPath);
            Relative = Path.Combine(basePath.Relative, restPath);

            EnsureDirectoryExists();
        }

        public CilAntroPath GetSimilarPath(string absolutePath)
        {
            if (!absolutePath.StartsWith(Absolute))
                throw new ArgumentException($"The provided path doesn't match the path '{Absolute}'.");

            return new CilAntroPath(Absolute, absolutePath.Substring(Absolute.Length));
        }

        public CilAntroPath GetDeepestPath(string deepestPath)
        {
            if (deepestPath.StartsWith("\\") || deepestPath.StartsWith("/"))
                deepestPath = deepestPath.Substring(1);

            return new CilAntroPath(this, deepestPath);
        }

        public void ClearDirectory()
        {
            if (!string.IsNullOrEmpty(Path.GetExtension(Absolute)))
                return;

            Directory.Delete(Absolute, true);
            EnsureDirectoryExists();
        }

        protected void EnsureDirectoryExists()
        {
            if (!string.IsNullOrEmpty(Path.GetExtension(Absolute)))
                return;

            if (!Directory.Exists(Absolute))
            {
                Directory.CreateDirectory(Absolute);
            }
        }
    }

    public class TestsPaths : CilAntroPath
    {
        public TestsPaths(string testsDirectoryPath)
            : base(testsDirectoryPath)
        {
        }
    }

    public class TestsDataPaths : CilAntroPath
    {
        public IlSourcesPaths IlSources => new IlSourcesPaths(this);

        public ExecsPaths Execs => new ExecsPaths(this);

        public GenerateExeOutputsPaths GenerateExeOutputs => new GenerateExeOutputsPaths(this);

        public TestsDataPaths(string testsDataDirectoryPath)
            : base(testsDataDirectoryPath)
        {
        }
    }

    public class IlSourcesPaths : CilAntroPath
    {
        public TestIlSourcesPaths this[string testName] => new TestIlSourcesPaths(this, testName);

        public IlSourcesPaths(TestsDataPaths testsDataPaths)
            : base(testsDataPaths, "il-sources")
        {
        }
    }

    public class TestIlSourcesPaths : CilAntroPath
    {
        private readonly string _testName;

        public CilAntroPath MainIlSourcePaths => new CilAntroPath(this, $"{_testName}.il");

        public TestIlSourcesPaths(IlSourcesPaths ilSourcesPaths, string testName)
            : base(ilSourcesPaths, testName)
        {
            _testName = testName;
        }
    }

    public class ExecsPaths : CilAntroPath
    {
        public TestExecsPaths this[string testName] => new TestExecsPaths(this, testName);

        public ExecsPaths(TestsDataPaths testsDataPaths)
            : base(testsDataPaths, "execs")
        {
        }
    }

    public class TestExecsPaths : CilAntroPath
    {
        private readonly string _testName;

        public CilAntroPath MainExePaths => new CilAntroPath(this, $"{_testName}.exe");

        public TestExecsPaths(ExecsPaths execsPaths, string testName)
            : base(execsPaths, testName)
        {
            _testName = testName;
        }
    }

    public class GenerateExeOutputsPaths : CilAntroPath
    {
        public TestGenerateExeOutputsPaths this[string testName] => new TestGenerateExeOutputsPaths(this, testName);

        public GenerateExeOutputsPaths(TestsDataPaths testsDataPaths)
            : base(testsDataPaths, "generate-exe-outputs")
        {
        }
    }

    public class TestGenerateExeOutputsPaths : CilAntroPath
    {
        private readonly string _testName;

        public CilAntroPath MainOutputPaths => new CilAntroPath(this, $"{_testName}.out");

        public TestGenerateExeOutputsPaths(GenerateExeOutputsPaths generateExeOutputsPaths, string testName)
            : base(generateExeOutputsPaths, testName)
        {
            _testName = testName;
        }
    }

    public class RunsDataPaths : CilAntroPath
    {
        public RunDataPaths this[Guid runId] => new RunDataPaths(this, runId);

        public RunsDataPaths(string runsDataDirectoryPath)
            : base(runsDataDirectoryPath)
        {
        }
    }

    public class RunDataPaths : CilAntroPath
    {
        private readonly Guid _runId;

        public TestRunDataPaths this[Guid testRunId] => new TestRunDataPaths(this, testRunId);

        public RunDataPaths(RunsDataPaths runsDataPaths, Guid runId)
            : base(runsDataPaths, runId.ToString())
        {
            _runId = runId;
        }
    }

    public class TestRunDataPaths : CilAntroPath
    {
        private readonly Guid _testRunId;

        public TestRunInputsPaths Inputs => new TestRunInputsPaths(this);

        public TestRunOutputsPaths Outputs => new TestRunOutputsPaths(this);

        public TestRunErrorsPaths Errors => new TestRunErrorsPaths(this);

        public TestRunCilAntroOutputsPaths CilAntroOutputs => new TestRunCilAntroOutputsPaths(this);

        public TestRunCilAntroErrorsPaths CilAntroErrors => new TestRunCilAntroErrorsPaths(this);

        public TestRunDataPaths(RunDataPaths runDataPaths, Guid testRunId)
            : base(runDataPaths, testRunId.ToString())
        {
            _testRunId = testRunId;
        }
    }

    public class TestRunInputsPaths : CilAntroPath
    {
        public CilAntroPath this[string inputName] => new CilAntroPath(this, $"{inputName}.in");

        public TestRunInputsPaths(TestRunDataPaths testRunDataPaths)
            : base(testRunDataPaths, "inputs")
        {
        }
    }

    public class TestRunOutputsPaths : CilAntroPath
    {
        public CilAntroPath this[string outputName] => new CilAntroPath(this, $"{outputName}.out");

        public TestRunOutputsPaths(TestRunDataPaths testRunDataPaths)
            : base(testRunDataPaths, "outputs")
        {
        }
    }

    public class TestRunErrorsPaths : CilAntroPath
    {
        public CilAntroPath this[string errorName] => new CilAntroPath(this, $"{errorName}.err");

        public TestRunErrorsPaths(TestRunDataPaths testRunDataPaths)
            : base(testRunDataPaths, "errors")
        {
        }
    }

    public class TestRunCilAntroOutputsPaths : CilAntroPath
    {
        public CilAntroPath this[string outputName] => new CilAntroPath(this, $"{outputName}.out");

        public TestRunCilAntroOutputsPaths(TestRunDataPaths testRunDataPaths)
            : base(testRunDataPaths, "cilantro-outputs")
        {
        }
    }

    public class TestRunCilAntroErrorsPaths : CilAntroPath
    {
        public CilAntroPath this[string errorName] => new CilAntroPath(this, $"{errorName}.err");

        public TestRunCilAntroErrorsPaths(TestRunDataPaths testRunDataPaths)
            : base(testRunDataPaths, "cilantro-errors")
        {
        }
    }
}