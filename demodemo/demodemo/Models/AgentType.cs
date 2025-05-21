using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class AgentType
{
    public int IdAgentType { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();
}
