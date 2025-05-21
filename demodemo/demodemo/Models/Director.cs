using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class Director
{
    public int IdDirector { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
