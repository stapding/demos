using System;
using System.Collections.Generic;

namespace WpfDEMO.Models;

public partial class Deliver
{
    public int IdDeliver { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
