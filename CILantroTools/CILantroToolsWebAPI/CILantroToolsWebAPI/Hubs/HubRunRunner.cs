using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using CILantroToolsWebAPI.Exceptions;
using CILantroToolsWebAPI.Models.Runs;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.ReadModels.Tests;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class HubRunRunner
    {
        private IServiceScopeFactory _serviceScopeFactory;

        private IHubContext<RunningRunHub> _hubContext;

        private Task _processingTask;

        private RunData _processingRunData;

        private DateTime? _processingStartedOn;

        private DateTime? _processingFinishedOn;

        public RunReadModel ProcessingRun;

        public HubRunRunner(
            IServiceScopeFactory serviceScopeFactory,
            IHubContext<RunningRunHub> hubContext
        )
        {
            _serviceScopeFactory = serviceScopeFactory;
            _hubContext = hubContext;
        }

        public async void Run(Guid runId)
        {
            if (_processingTask != null)
                await CancelExistingRun();

            _processingTask = Task.Run(async () =>
            {
                _processingStartedOn = DateTime.Now;

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();

                    ProcessingRun = runsRepository.Read<RunReadModel>().SingleOrDefault(r => r.Id == runId);
                    _processingRunData = new RunData(ProcessingRun);

                    if (ProcessingRun == null)
                        throw new ToolsException($"Cannot find run with id {runId}.");
                }

                SaveRunData();

                foreach (var testRun in ProcessingRun.TestRuns)
                {
                    await ProcessTestRun(testRun);
                }

                _processingFinishedOn = DateTime.Now;
                _processingRunData.Status = RunStatus.Finished;

                SendRunData();
                await SaveRunData();

                ProcessingRun = null;
                _processingRunData = null;
                _processingTask = null;
                _processingStartedOn = null;
                _processingFinishedOn = null;
            });
        }

        public async Task CancelExistingRun()
        {
            if (ProcessingRun != null)
            {
                if (_processingTask != null)
                {
                    _processingTask.Dispose();
                }

                _processingRunData.Status = RunStatus.Cancelled;
                await SaveRunData();
                
                ProcessingRun = null;
                _processingRunData = null;
                _processingTask = null;
                _processingStartedOn = null;
                _processingFinishedOn = null;
            }
        }

        private async Task ProcessTestRun(TestRunReadModel testRun)
        {
            TestReadModel test;
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var testsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Test>>();
                test = testsRepository.Read<TestReadModel>().SingleOrDefault(t => t.Id == testRun.TestId);
            }

            _processingRunData.CurrentTestIntId = test.IntId;
            _processingRunData.CurrentTestName = test.Name;

            SendRunData();

            await Task.Delay(2000);
        }

        private void SendRunData()
        {
            if (_processingStartedOn.HasValue && _processingFinishedOn.HasValue)
                _processingRunData.ProcessedForSeconds = (int?)(_processingFinishedOn - _processingStartedOn).Value.TotalSeconds;
            else if (_processingStartedOn.HasValue)
                _processingRunData.ProcessedForSeconds = (int?)(DateTime.Now - _processingStartedOn).Value.TotalSeconds;

            _hubContext.Clients.All.SendAsync("update-run-data", _processingRunData);
        }

        private async Task SaveRunData()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();
                await runsRepository.UpdateAsync(r => r.Id == ProcessingRun.Id, r =>
                {
                    r.Status = _processingRunData.Status;
                    r.ProcessingStartedOn = _processingStartedOn;
                    r.ProcessingFinishedOn = _processingFinishedOn;
                });
            }
        }
    }
}