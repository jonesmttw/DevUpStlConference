using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.ApiTriggers;

public class ApiFunctions
{
    private readonly ILogger<ApiFunctions> _logger;

    public ApiFunctions(ILogger<ApiFunctions> logger)
    {
        _logger = logger;
    }

    [Function("ApiFunctions")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", "delete", Route = "mattjones")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
