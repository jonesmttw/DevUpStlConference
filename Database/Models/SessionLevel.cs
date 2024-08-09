using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.Database.Models;

public partial class SessionLevel
{
    public Guid SessionLevelId { get; set; } = default!;
    public string SessionLevelName { get; set; } = default!;

    public ICollection<Session> Sessions { get; set; } = default!;
}
