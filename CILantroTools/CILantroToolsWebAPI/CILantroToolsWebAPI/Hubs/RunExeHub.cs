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
        private readonly TestsService _testsService;

        private readonly IHubContext<RunExeHub> _hubContext;

        private static StreamWriter _processWriter;
        private static StreamReader _processReader;

        public RunExeHub(TestsService testsService, IHubContext<RunExeHub> hubContext)
        {
            _testsService = testsService;
            _hubContext = hubContext;
        }

        public async Task RunExe(Guid testId)
        {
            var test = await _testsService.GetTestAsync(testId);

            var exeProcessStartInfo = new ProcessStartInfo(test.ExePathFull)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            var process = Process.Start(exeProcessStartInfo);
            //await Clients.Caller.SendAsync("start");
            await _hubContext.Clients.All.SendAsync("start");
            //var context = GlobalHost.ConnectionManager.GetHubContext<SomeHub>();
            //context.Clients.Client(connectionId).SendComplete(message);

            _processWriter = process.StandardInput;
            _processReader = process.StandardOutput;


            await Task.Run(async () =>
            {
                while (!_processReader.EndOfStream)
                {
                    var outLine = await _processReader.ReadLineAsync();
                    await _hubContext.Clients.All.SendAsync("out", outLine);
                }
            });

            await _hubContext.Clients.All.SendAsync("end");
        }

        public async Task In(string message)
        {
            await _processWriter.WriteLineAsync(message);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}