using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DevUpConference.TimerTriggers;

public class EmailUpcomingSessions
{
    private readonly ILogger _logger;
    private readonly ITimerService _timerService;

    public EmailUpcomingSessions(ILoggerFactory loggerFactory, ITimerService timerService)
    {
        _logger = loggerFactory.CreateLogger<EmailUpcomingSessions>();

        _timerService = timerService;
    }

    [Function(nameof(EmailUpcomingSessions))]
    // runs every hour
    public async Task Run([TimerTrigger("0 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        await _timerService.EmailUpcomingSessionsAsync();
    }
}
