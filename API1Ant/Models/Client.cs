using System;
using System.Collections.Generic;

namespace API1Ant.Models;

public partial class Client
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public long CatalogueId { get; set; }

    public long OrderId { get; set; }

    public virtual Catalogue Catalogue { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
