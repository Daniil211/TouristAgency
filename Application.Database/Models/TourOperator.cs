using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class TourOperator
{
    public int OperatorId { get; set; }

    public string Fio { get; set; } = null!;

    public int? Age { get; set; }

    public string? Resume { get; set; }
    public string? Image { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
