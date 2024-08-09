using DevUpConference.Database;
using DevUpConference.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.QueueTriggers;

public interface IQueueService
{
    Task ProcessFeedbackAsync(Feedback feedback);
}
public class QueueService : IQueueService
{
    private readonly DevUpDbContext _context;
    public QueueService(DevUpDbContext context)
    {
        _context = context;
    }

    public async Task ProcessFeedbackAsync(Feedback feedback)
    {
        await _context.Feedbacks.AddAsync(feedback);

        await _context.SaveChangesAsync();
    }
}
