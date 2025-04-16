using System;
using System.Collections.Generic;

namespace WpfFinalDemo.Models;

public partial class Post
{
    public int IdPost { get; set; }

    public int? Postcode { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? Home { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
