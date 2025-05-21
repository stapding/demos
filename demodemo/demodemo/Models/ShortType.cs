using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class ShortType
{
    public int IdShortType { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Short> Shorts { get; set; } = new List<Short>();
}
