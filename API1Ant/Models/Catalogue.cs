using System;
using System.Collections.Generic;

namespace API1Ant.Models;

public partial class Catalogue
{
    public long Id { get; set; }

    public decimal SilverClocks { get; set; }

    public decimal Necklace { get; set; }

    public decimal MusicBox { get; set; }

    public decimal Ring { get; set; }

    public decimal Vase { get; set; }

    public decimal Mirror { get; set; }

    public decimal Coin { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
