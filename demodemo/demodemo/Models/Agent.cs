using System;
using System.Collections.Generic;

namespace demodemo.Models;

public partial class Agent
{
    public int IdAgent { get; set; }

    public int? IdAgentType { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Logo { get; set; }

    public int? IdAddress { get; set; }

    public int? Priority { get; set; }

    public int? IdDirector { get; set; }

    public string? Inn { get; set; }

    public string? Kpp { get; set; }

    public string? FullName
    {
        get
        {
            return $"{IdAgentTypeNavigation.Name} | {Name}";
        }
    }

    public string? FullImage
    {
        get
        {
            return $"Resources/agents/{(string.IsNullOrEmpty(Logo) ? "picture.png" : Logo)}";
        }
    }

    public int? Discount
    {
        get
        {
            var totalSales = AgentsShorts.Sum(a => a.Quantity);
            if(totalSales >= 0 && totalSales < 10000)
            {
                return 0;
            } else if (totalSales >= 10000 && totalSales < 50000)
            {
                return 5;
            } else if (totalSales >= 50000 && totalSales < 150000)
            {
                return 10;
            } else if (totalSales >= 150000 && totalSales < 500000)
            {
                return 20;
            } else
            {
                return 25;
            }
        }
    }

    public string? Sales
    {
        get
        {
            return $"{AgentsShorts.Sum(a => a.Quantity)} продаж за год";
        }
    }

    public virtual ICollection<AgentsShort> AgentsShorts { get; set; } = new List<AgentsShort>();

    public virtual Address? IdAddressNavigation { get; set; }

    public virtual AgentType? IdAgentTypeNavigation { get; set; }

    public virtual Director? IdDirectorNavigation { get; set; }
}
