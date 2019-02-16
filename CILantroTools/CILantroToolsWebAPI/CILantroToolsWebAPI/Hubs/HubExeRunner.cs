﻿using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class HubExeRunner
    {
        private readonly IHubContext<RunExeHub> _hubContext;

        private Dictionary<string, Process> _processes;

        public HubExeRunner(IHubContext<RunExeHub> hubContext)
        {
            _hubContext = hubContext;

            _processes = new Dictionary<string, Process>();
        }

        public void Run(string connectionId, string exePath)
        {
            var processStartInfo = new ProcessStartInfo(exePath)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            var newProcess = Process.Start(processStartInfo);
            _processes.Add(connectionId, newProcess);

            Task
                .Run(() => { WatchOuput(connectionId); })
                .ContinueWith(ct => { _hubContext.Clients.Group(connectionId).SendAsync("end"); });

            _hubContext.Clients.Group(connectionId).SendAsync("start");
        }

        public void Input(string connectionId, string inputLine)
        {
            _processes[connectionId].StandardInput.WriteLineAsync(inputLine);
        }

        public async Task WatchOuput(string connectionId)
        {
            var standardOutput = _processes[connectionId].StandardOutput;

            while(!standardOutput.EndOfStream)
            {
                var outputLine = await standardOutput.ReadLineAsync();
                _hubContext.Clients.Group(connectionId).SendAsync("output", outputLine);
            }
        }
    }
}