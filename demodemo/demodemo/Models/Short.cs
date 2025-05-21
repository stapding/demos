using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class Short
{
    public int IdShort { get; set; }

    public string? Name { get; set; }

    public int? IdShortType { get; set; }

    public int? Articul { get; set; }

    public int? People { get; set; }

    public int? Num { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<AgentsShort> AgentsShorts { get; set; } = new List<AgentsShort>();

    public virtual ShortType? IdShortTypeNavigation { get; set; }
}
