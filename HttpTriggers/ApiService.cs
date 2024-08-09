using DevUpConference.Database;
using DevUpConference.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DevUpConference.ApiTriggers;

public interface IApiService
{
    public Task<IEnumerable<Session>> GetAllSessionsAsync();
    public Task<Session> GetSessionAsync(Guid sessionId);
    public Task<Guid> CreateNewSessionAsync(Session newSession);
    public Task<Guid> UpdateSessionAsync(Session updateSession);
}

public class ApiService : IApiService
{
    private readonly DevUpDbContext _context;
    public ApiService(DevUpDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Session>> GetAllSessionsAsync()
    {
        var sessions = await _context.Sessions.ToListAsync();

        return sessions;
    }

    public async Task<Session> GetSessionAsync(Guid sessionId)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(x => x.SessionId == sessionId);
        if (session is null)
        {
            throw new Exception($"Session ID {sessionId} not found");
        }

        return session;
    }

    public async Task<Guid> CreateNewSessionAsync(Session newSession)
    {
        var session = await _context.Sessions.AddAsync(newSession);

        await _context.SaveChangesAsync();

        return session.Entity.SessionId;
    }

    public async Task<Guid> UpdateSessionAsync(Session updateSession)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(x => x.SessionId == updateSession.SessionId);
        if (session is null)
        {
            throw new Exception($"Session ID {updateSession.SessionId} not found");
        }

        session.SessionDescription = updateSession.SessionDescription;
        session.SessionLevel = updateSession.SessionLevel;
        session.SessionRoom = updateSession.SessionRoom;
        session.SessionTime = updateSession.SessionTime;
        session.SessionTitle = updateSession.SessionTitle;

        _context.Sessions.Update(session);

        await _context.SaveChangesAsync();

        return session.SessionId;
    }
}
