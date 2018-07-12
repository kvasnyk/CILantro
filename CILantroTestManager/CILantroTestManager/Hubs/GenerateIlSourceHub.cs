using CILantroTestManager.Services;
using Microsoft.AspNet.SignalR;
using System;

namespace CILantroTestManager.Hubs
{
    public class GenerateIlSourceHub : Hub
    {
        private readonly TestsService _testsService;

        public GenerateIlSourceHub()
        {
            _testsService = new TestsService();
        }

        public void Generate(Guid testId)
        {
            Clients.Caller.logInfo("Looking for test...");
            Clients.Caller.closeLogGroup();

            var test = _testsService.ReadTest(testId);

            Clients.Caller.logSuccess($"Test found!");
            Clients.Caller.logSuccess($"ID       {testId}");
            Clients.Caller.logSuccess($"Name     {test.Name}");
            Clients.Caller.closeLogGroup();

            Clients.Caller.logInfo($"Generating IL source...");
            Clients.Caller.closeLogGroup();

            _testsService.GenerateIlSource(test.Id);

            Clients.Caller.logSuccess($"IL source generated!");
            Clients.Caller.closeLogGroup();

            Clients.Caller.finish();
        }
    }
}