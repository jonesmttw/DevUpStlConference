using Azure.Storage.Queues.Models;
using DevUpConference.Database.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.QueueTriggers;

public class ProcessFeedbackFromQueue
{
    private readonly ILogger<ProcessFeedbackFromQueue> _logger;
    private readonly IQueueService _queueService;

    public ProcessFeedbackFromQueue(ILogger<ProcessFeedbackFromQueue> logger, IQueueService queueService)
    {
        _logger = logger;

        _queueService = queueService;
    }

    [Function(nameof(ProcessFeedbackFromQueue))]
    // if you leave connection empty - it will use the value that is in your AzureWebJobsStorage local.settings.json
    public async Task Run([QueueTrigger("devupstlfeedback", Connection = "QueueStorageConnection")] Feedback queueFeedback)
    {
        _logger.LogInformation($"C# Queue trigger function processed");

        await _queueService.ProcessFeedbackAsync(queueFeedback);
    }
}
