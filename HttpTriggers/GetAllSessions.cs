using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.ApiTriggers;

public class GetAllSessions
{
    private readonly ILogger<GetAllSessions> _logger;
    private readonly IApiService _apiService;

    public GetAllSessions(ILogger<GetAllSessions> logger, IApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    [Function(nameof(GetAllSessions))]
    // can return IActionResult, HttpResult, HttpResponseData, or some JSON serializable object
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var sessions = await _apiService.GetAllSessionsAsync();

        return new JsonResult(sessions);
    }
}
