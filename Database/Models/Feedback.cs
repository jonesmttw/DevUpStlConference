namespace DevUpConference.Database.Models;

public partial class Feedback
{
    public Guid FeedbackId { get; set; } = default!;
    public string FeedbackText { get; set; } = default!;
    public int FeedbackRating { get; set; } = default!;
}
