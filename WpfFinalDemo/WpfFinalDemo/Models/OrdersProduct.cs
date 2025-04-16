using System;
using System.Collections.Generic;

namespace WpfFinalDemo.Models;

public partial class OrdersProduct
{
    public int IdOrder { get; set; }

    public string IdProduct { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
