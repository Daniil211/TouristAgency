using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int TourId { get; set; }

    public int ClientId { get; set; }

    public int? ToutOperatorId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Tour Tour { get; set; } = null!;

    public virtual TourOperator? ToutOperator { get; set; }
}
