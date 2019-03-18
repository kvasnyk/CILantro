using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Enums;
using CILantroToolsWebAPI.Exceptions;
using CILantroToolsWebAPI.ReadModels.Runs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Hubs
{
    public class HubRunRunner
    {
        private IServiceScopeFactory _serviceScopeFactory;

        private Task _processingTask;

        public RunReadModel ProcessingRun;

        public HubRunRunner(
            IServiceScopeFactory serviceScopeFactory
        )
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async void Run(Guid runId)
        {
            if (_processingTask != null)
                await CancelExistingRun();

            _processingTask = Task.Run(async () =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();

                    ProcessingRun = runsRepository.Read<RunReadModel>().SingleOrDefault(r => r.Id == runId);

                    if (ProcessingRun == null)
                        throw new ToolsException($"Cannot find run with id {runId}.");

                    await runsRepository.UpdateAsync(r => r.Id == runId, r =>
                    {
                        r.ProcessingStartedOn = DateTime.Now;
                    });
                }
            });
        }

        public async Task CancelExistingRun()
        {
            if (ProcessingRun != null)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var runsRepository = scope.ServiceProvider.GetRequiredService<AppKeyRepository<Run>>();

                    await runsRepository.UpdateAsync(r => r.Id == ProcessingRun.Id, r =>
                    {
                        r.Status = RunStatus.Cancelled;
                    });
                }

                _processingTask.Dispose();
                _processingTask = null;
                ProcessingRun = null;
            }
        }
    }
}