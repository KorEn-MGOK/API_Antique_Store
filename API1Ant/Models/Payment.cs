using System;
using System.Collections.Generic;

namespace API1Ant.Models;

public partial class Payment
{
    public long Id { get; set; }

    public long OrderId { get; set; }

    public long ClientsId { get; set; }

    public int Sum { get; set; }

    public virtual Client Clients { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
