using CILantroTestManager.Services;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CILantroTestManager.Hubs
{
    public class GenerateExeHub : Hub
    {
        private readonly TestsService _testsService;

        public GenerateExeHub()
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

            Clients.Caller.logInfo($"Generating EXE...");
            Clients.Caller.closeLogGroup();

            _testsService.GenerateExe(test.Id);

            Clients.Caller.logSuccess($"EXE generated!");
            Clients.Caller.closeLogGroup();

            Clients.Caller.finish();
        }
    }
}