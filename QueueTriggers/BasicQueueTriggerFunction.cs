using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.QueueTriggers;

public class BasicQueueTriggerFunction
{
    private readonly ILogger<BasicQueueTriggerFunction> _logger;

    public BasicQueueTriggerFunction(ILogger<BasicQueueTriggerFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BasicQueueTriggerFunction))]
    // if you want to send a message to another queue on completion, you can use the QueueOutput decorator 
    // you would return either string[], byte[], oor JSON Serializable type
    //[QueueOutput("output-queue")]
    // can bind to string, byte[], BinaryData, QueueMessage, or JSON Serializable type
    public void Run([QueueTrigger("devupstlqueue", Connection = "QueueStorageConnection")] QueueMessage message)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
    }
}
