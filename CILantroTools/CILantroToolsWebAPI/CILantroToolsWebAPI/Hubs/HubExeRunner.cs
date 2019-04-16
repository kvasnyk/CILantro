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

            var outputTask = Task.Run(() => { WatchOutput(connectionId); });
            var errorTask = Task.Run(() => { WatchError(connectionId); });

            Task.WhenAll(outputTask, errorTask)
                .ContinueWith(async ct =>
                {
                    await Task.Delay(1000);
                    _hubContext.Clients.Group(connectionId).SendAsync("end");
                });

            _hubContext.Clients.Group(connectionId).SendAsync("start");
        }

        public void Input(string connectionId, string inputLine)
        {
            _processes[connectionId].StandardInput.WriteLineAsync(inputLine);
        }

        public void Kill(string connectionId)
        {
            if (!_processes[connectionId].HasExited)
            {
                _processes[connectionId].Kill();
                _processes.Remove(connectionId);
            }
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