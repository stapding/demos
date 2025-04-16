using System;
using System.Collections.Generic;

namespace WpfDEMO.Models;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string? Name { get; set; }

    public string? Unit { get; set; }

    public int? Cost { get; set; }

    public int? MaxSale { get; set; }

    public int? IdManufacturer { get; set; }

    public int? IdDeliver { get; set; }

    public int? IdCategory { get; set; }

    public int? CurrentSale { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string FullImage
    {
        get
        {
            return $"Resources/{(string.IsNullOrEmpty(Image) ? "picture.png" : Image)}";
        }
    }

    public string Color
    {
        get
        {
            if (Quantity >= 10)
            {
                return "#ffffff";
            } 
            else
            {
                return "#7fff00";
            }
        }
    }
    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Deliver? IdDeliverNavigation { get; set; }

    public virtual Manufacturer? IdManufacturerNavigation { get; set; }

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();

    public int GetPriceWithDiscount()
    {
        int baseCost = Cost ?? 0;
        int discount = CurrentSale ?? 0;

        return baseCost - (baseCost * discount / 100);
    }
}
