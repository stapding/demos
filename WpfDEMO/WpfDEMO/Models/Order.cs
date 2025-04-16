using System;
using System.Collections.Generic;

namespace WpfDEMO.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateOnly? DateOrder { get; set; }

    public DateOnly? DateDeliver { get; set; }

    public int? IdPost { get; set; }

    public string? ClientFio { get; set; }

    public int? Code { get; set; }

    public int? IdStatus { get; set; }

    // Свойство полной суммы заказа
    public int TotalPrice => CalculateTotalOrderPrice();

    public int TotalQuantity => CalculateTotalQuantity();

    // Список наименований товаров через запятую
    public string ProductNames => string.Join(", ", OrdersProducts.Select(op => op.IdProductNavigation.Name));

    public virtual Post? IdPostNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual ICollection<OrdersProduct> OrdersProducts { get; set; } = new List<OrdersProduct>();

    // Метод расчета полной суммы заказа
    public int CalculateTotalOrderPrice()
    {
        int total = 0;

        foreach (var orderProduct in OrdersProducts)
        {
            var product = orderProduct.IdProductNavigation;
            if (product != null && orderProduct.Quantity.HasValue)
            {
                int priceWithDiscount = product.GetPriceWithDiscount();
                total += priceWithDiscount * orderProduct.Quantity.Value;
            }
        }

        return total;
    }

    public int CalculateTotalQuantity()
    {
        int total = 0;

        foreach (var orderProduct in OrdersProducts)
        {
            total =+ orderProduct.Quantity.Value;
        }

        return total;
    }
}
