using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class AgentsShort
{
    public int IdShort { get; set; }

    public int IdAgent { get; set; }

    public DateOnly? DateRealisation { get; set; }

    public int? Quantity { get; set; }

    public virtual Agent IdAgentNavigation { get; set; } = null!;

    public virtual Short IdShortNavigation { get; set; } = null!;
}
