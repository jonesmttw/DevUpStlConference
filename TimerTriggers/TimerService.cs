using DevUpConference.Database;
using Microsoft.EntityFrameworkCore;

namespace DevUpConference.TimerTriggers;

public interface ITimerService
{
    Task EmailUpcomingSessionsAsync();
}

public class TimerService : ITimerService
{
    private readonly DevUpDbContext _context;
    public TimerService(DevUpDbContext context)
    {
        _context = context;
    }

    public async Task EmailUpcomingSessionsAsync()
    {
        var sessions = await _context.Sessions.Where(x => x.SessionTime > DateTime.Now.AddHours(-1) && x.SessionTime < DateTime.Now.AddMinutes(90)).ToListAsync();

        var attendees = await _context.Attendees.ToListAsync();

        // placeholder for email attendees functionality
    }
}
