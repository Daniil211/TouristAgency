using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int TourId { get; set; }

    public int UserId { get; set; }

    public int? TourOperatorId { get; set; }

    public virtual User? User { get; set; } = null!;

    public virtual Tour? Tour { get; set; } = null!;

    public virtual TourOperator? TourOperator { get; set; }
}
