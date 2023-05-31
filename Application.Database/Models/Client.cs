using System;
using System.Collections.Generic;

namespace Application.Database.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Fio { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
