using DevUpConference.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DevUpConference.ApiTriggers;

public class UpdateSession
{
    private readonly ILogger<UpdateSession> _logger;
    private readonly IApiService _apiService;

    public UpdateSession(ILogger<UpdateSession> logger, IApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    [Function(nameof(UpdateSession))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        try
        {
            var newSession = await JsonSerializer.DeserializeAsync<Session>(req.Body);
            if (newSession is null)
            {
                return new BadRequestObjectResult("Invalid Session Object");
            }

            var sessionId = await _apiService.UpdateSessionAsync(newSession);

            return new JsonResult(sessionId);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
