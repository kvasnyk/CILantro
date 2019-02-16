using CILantroToolsWebAPI.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class RunExeHub : Hub
    {
        private readonly TestsService _testsService;

        private readonly HubExeRunner _exeRunner;

        public RunExeHub(TestsService testsService, HubExeRunner exeRunner)
        {
            _testsService = testsService;
            _exeRunner = exeRunner;
        }

        public async Task Run(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);
            _exeRunner.Run(Context.ConnectionId, test.ExePathFull);
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