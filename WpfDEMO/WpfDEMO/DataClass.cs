using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDEMO.Models;

namespace WpfDEMO
{
    public class DataClass
    {
        public static DemodbContext context = new DemodbContext();

        public static List<Product> GetProducts()
        {
            return context.Products
                .Include(p => p.IdCategoryNavigation)
                .Include(p => p.IdDeliverNavigation)
                .Include(p => p.IdManufacturerNavigation)
                .ToList();
        }

        public static List<Order> GetOrders()
        {
            return context.Orders
                .Include(o => o.OrdersProducts)
                    .ThenInclude(op => op.IdProductNavigation)
                .Include(o => o.IdStatusNavigation)
                .Include(o => o.IdPostNavigation)
                .ToList();
        }

        public static List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public static List<Manufacturer> GetManufacturers()
        {
            return context.Manufacturers.ToList();
        }

        public static List<Deliver> GetDelivers()
        {
            return context.Delivers.ToList();
        }

        public static bool AddProduct(Product product)
        {
            try
            {
                // Проверка на существующий артикул
                if (context.Products.Any(p => p.IdProduct == product.IdProduct))
                {
                    return false;
                }

                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void DeleteProduct(Product product)
        {
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public static void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = context.Products.FirstOrDefault(p => p.IdProduct == updatedProduct.IdProduct);
            if (existingProduct != null)
            {
                context.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
                context.SaveChanges();
            }
        }


        public static User Authenticate(string login, string password)
        {
            return context.Users.Include(p => p.IdRoleNavigation).FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
