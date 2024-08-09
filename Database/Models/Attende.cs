using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.Database.Models;

public partial class Attende
{
    public Guid AttendeId { get; set; } = default!;
    public string AttendeFirstName { get; set; } = default!;
    public string AttendeLastName { get; set; } = default!;
    public string AttendeEmailAddress { get; set; } = default!;
}
