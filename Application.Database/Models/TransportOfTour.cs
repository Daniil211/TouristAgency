using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class TransportOfTour
{
    public int TourId { get; set; }

    public int Id { get; set; }

    public int TransportId { get; set; }

    public virtual Tour Tour { get; set; } = null!;

    public virtual Transport Transport { get; set; } = null!;
}
