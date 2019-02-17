using CILantroToolsWebAPI.Services;
using CILantroToolsWebAPI.Settings;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class ExecuteTestHub : Hub
    {
        private readonly IOptions<AppSettings> _appSettings;

        private readonly TestsService _testsService;

        private readonly HubExeRunner _exeRunner;

        public ExecuteTestHub(IOptions<AppSettings> appSettings, TestsService testsService, HubExeRunner exeRunner)
        {
            _appSettings = appSettings;
            _testsService = testsService;
            _exeRunner = exeRunner;
        }

        public async Task RunExe(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);
            _exeRunner.Run(Context.ConnectionId, test.ExePathFull);
        }

        public async Task RunInterpreter(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);
            _exeRunner.Run(Context.ConnectionId, _appSettings.Value.CILantroExePath);
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