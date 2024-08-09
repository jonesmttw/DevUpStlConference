using DevUpConference.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DevUpConference.ApiTriggers;

public class CreateNewSession
{
    private readonly ILogger<CreateNewSession> _logger;
    private readonly IApiService _apiService;

    public CreateNewSession(ILogger<CreateNewSession> logger, IApiService apiService)
    {
        _logger = logger;
        _apiService = apiService;
    }

    [Function(nameof(CreateNewSession))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        try
        {
            var newSession = await JsonSerializer.DeserializeAsync<Session>(req.Body);
            if(newSession is null)
            {
                return new BadRequestObjectResult("Invalid Session Object");
            }

            var sessionId = await _apiService.CreateNewSessionAsync(newSession);

            return new JsonResult(sessionId);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
