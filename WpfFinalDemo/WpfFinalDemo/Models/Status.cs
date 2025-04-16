using System;
using System.Collections.Generic;

namespace WpfFinalDemo.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
