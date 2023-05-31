using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class Transport
{
    public int TransportId { get; set; }

    public string TypeOfTransport { get; set; } = null!;

    public virtual ICollection<TransportOfTour> TransportOfTours { get; set; } = new List<TransportOfTour>();
}
