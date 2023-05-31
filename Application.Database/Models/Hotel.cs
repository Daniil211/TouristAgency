using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public int CountOfStars { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<HotelsOfTour> HotelsOfTours { get; set; } = new List<HotelsOfTour>();
}
