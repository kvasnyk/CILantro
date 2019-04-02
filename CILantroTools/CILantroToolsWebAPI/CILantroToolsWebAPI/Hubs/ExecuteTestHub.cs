using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using CILantroToolsWebAPI.Utils;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class ExecuteTestHub : Hub
    {
        private readonly Paths _paths;

        private readonly IOptions<AppSettings> _appSettings;

        private readonly TestsService _testsService;

        private readonly HubExeRunner _exeRunner;

        public ExecuteTestHub(
            Paths paths,
            IOptions<AppSettings> appSettings,
            TestsService testsService,
            HubExeRunner exeRunner
        )
        {
            _paths = paths;
            _appSettings = appSettings;
            _testsService = testsService;
            _exeRunner = exeRunner;
        }

        public async Task RunExe(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);
            var testExePath = _paths.TestsData.Execs[test.Name].MainExePaths.Absolute;
            _exeRunner.Run(Context.ConnectionId, testExePath);
        }

        public async Task RunInterpreter(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);
            var testIlSourcePath = _paths.TestsData.IlSources[test.Name].MainIlSourcePaths.Absolute;
            var cilAntroArguments = $"--fileName \"{testIlSourcePath}\"";
            _exeRunner.Run(Context.ConnectionId, _appSettings.Value.CILantroExePath, cilAntroArguments);
        }

        public void Input(string inputLine)
        {
            _exeRunner.Input(Context.ConnectionId, inputLine);
        }

        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}