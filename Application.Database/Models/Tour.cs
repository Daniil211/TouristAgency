using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class Tour
{
    public int TourId { get; set; }

    public string TourName { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public decimal Price { get; set; }

    public byte[]? Image { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<HotelsOfTour> HotelsOfTours { get; set; } = new List<HotelsOfTour>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<TransportOfTour> TransportOfTours { get; set; } = new List<TransportOfTour>();
}
