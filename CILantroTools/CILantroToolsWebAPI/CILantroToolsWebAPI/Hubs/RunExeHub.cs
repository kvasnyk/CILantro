using CILantroToolsWebAPI.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class RunExeHub : Hub
    {
        private class RunExeHubWatcher
        {
            private readonly IHubContext<RunExeHub> _hubContext;

            public RunExeHubWatcher(IHubContext<RunExeHub> hubContext)
            {
                _hubContext = hubContext;
            }

            public async void Watch(Process process)
            {
                while (!process.StandardOutput.EndOfStream)
                {
                    var outputLine = await process.StandardOutput.ReadLineAsync();
                    await _hubContext.Clients.All.SendAsync("out", outputLine);
                }

                if (!process.HasExited) process.Kill();
                await _hubContext.Clients.All.SendAsync("end");
            }
        }

        private readonly TestsService _testsService;

        private static Process _process;

        private IHubContext<RunExeHub> _hubContext;

        public RunExeHub(TestsService testsService, IHubContext<RunExeHub> hubContext)
        {
            _testsService = testsService;
            _hubContext = hubContext;
        }

        public async Task Run(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);

            var exeProcessStartInfo = new ProcessStartInfo(test.ExePathFull)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            if (_process != null && !_process.HasExited)
            {
                _process.Kill();
            }

            _process = Process.Start(exeProcessStartInfo);
            await Clients.Caller.SendAsync("start");

            Task.Run(() => { new RunExeHubWatcher(_hubContext).Watch(_process); } );
        }

        public async Task Input(string inputLine)
        {
            if (_process != null)
            {
                await _process.StandardInput.WriteLineAsync(inputLine);
            }
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}