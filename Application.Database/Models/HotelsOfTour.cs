using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class HotelsOfTour
{
    public int Id { get; set; }

    public int TourId { get; set; }

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Tour Tour { get; set; } = null!;
}
