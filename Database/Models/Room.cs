using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevUpConference.Database.Models;

public partial class Room
{
    public Guid RoomId { get; set; }
    public string RoomNumber { get; set; } = default!;
}
