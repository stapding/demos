using System;
using System.Collections.Generic;

namespace WpfFinalDemo.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateOnly? DateOrder { get; set; }

    public DateOnly? DateDeliver { get; set; }

    public int? IdPost { get; set; }

    public string? FioClient { get; set; }

    public int? Code { get; set; }

    public int? IdStatus { get; set; }

    public virtual Post? IdPostNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();
}
