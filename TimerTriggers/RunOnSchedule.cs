using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.TimerTriggers;

// when adding a Timer Function, the NuGet package is required
// Microsoft.Azure.Functions.Worker.Extensions.Timer

// To manually trigger a Timer Function in Azure - you can call an admin URL
// https://learn.microsoft.com/en-us/azure/azure-functions/functions-manually-run-non-http?tabs=azure-portal

public class RunOnSchedule
{
    private readonly ILogger _logger;

    public RunOnSchedule(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<RunOnSchedule>();
    }

    [Function("RunOnSchedule")]
    public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}
