using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class HubExeRunner
    {
        private readonly IHubContext<ExecuteTestHub> _hubContext;

        private Dictionary<string, Process> _processes;

        public HubExeRunner(IHubContext<ExecuteTestHub> hubContext)
        {
            _hubContext = hubContext;

            _processes = new Dictionary<string, Process>();
        }

        public void Run(string connectionId, string exePath, string arguments = null)
        {
            var processStartInfo = new ProcessStartInfo(exePath, arguments)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            var newProcess = Process.Start(processStartInfo);
            _processes.Add(connectionId, newProcess);

            Task
                .Run(() => { WatchOutput(connectionId); })
                .ContinueWith(async ct =>
                {
                    await Task.Delay(300);
                    _hubContext.Clients.Group(connectionId).SendAsync("end");
                });

            Task.Run(() => { WatchError(connectionId); });

            _hubContext.Clients.Group(connectionId).SendAsync("start");
        }

        public void Input(string connectionId, string inputLine)
        {
            _processes[connectionId].StandardInput.WriteLineAsync(inputLine);
        }

        private async Task WatchOutput(string connectionId)
        {
            var standardOutput = _processes[connectionId].StandardOutput;

            while (!standardOutput.EndOfStream)
            {
                var outputLine = await standardOutput.ReadLineAsync();
                _hubContext.Clients.Group(connectionId).SendAsync("output", outputLine);
            }
        }

        private async Task WatchError(string connectionId)
        {
            var standardError = _processes[connectionId].StandardError;

            while (!standardError.EndOfStream)
            {
                var errorLine = await standardError.ReadLineAsync();
                _hubContext.Clients.Group(connectionId).SendAsync("error", errorLine);
            }
        }
    }
}