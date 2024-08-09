using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.ApiTriggers;

public class GetSessionById
{
    private readonly ILogger<GetSessionById> _logger;
    private readonly IApiService _apiService;

    public GetSessionById(ILogger<GetSessionById> logger, IApiService apiService)
    {
        _logger = logger;

        _apiService = apiService;
    }

    [Function(nameof(GetSessionById))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req, Guid sessionId)
    {
        // will automatically bind sessionId to
        // ?sessionId=<GUID>

        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var session = await _apiService.GetSessionAsync(sessionId);

        return new JsonResult(session);
    }
}
