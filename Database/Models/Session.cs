using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.Database.Models;

public partial class Session
{
    public Guid SessionId { get; set; } = default!;
    public string SessionDescription { get; set; } = default!;
    public DateTime SessionTime { get; set; }
    public string SessionTitle { get; set; } = default!;
    public Speaker SessionSpeaker { get; set; } = default!;
    public Room SessionRoom { get; set; } = default!;
    public SessionLevel SessionLevel { get; set; } = default!;
}
