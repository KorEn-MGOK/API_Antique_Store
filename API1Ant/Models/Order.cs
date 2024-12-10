using System;
using System.Collections.Generic;

namespace API1Ant.Models;

public partial class Order
{
    public long Id { get; set; }

    public string Place { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int Number { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
