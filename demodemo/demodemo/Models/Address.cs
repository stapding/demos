using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class Address
{
    public int IdAddress { get; set; }

    public int? Postcode { get; set; }

    public string? Region { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? Home { get; set; }

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
