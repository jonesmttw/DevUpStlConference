using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.Database.Models;

public partial class Speaker
{
    public Guid SpeakerId { get; set; }
    public string SpeakerName { get; set; } = default!;
    public string SpeakerBio { get; set; } = default!;
    public string SpeakerJobTitle { get; set; } = default!;
    public string SpeakerWebsite { get; set; } = default!;
    public string SpeakerImage { get; set; } = default!;

    public ICollection<Session> Sessions { get; set; } = default!;
}
