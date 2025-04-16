using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfFinalDemo.Models;

namespace WpfFinalDemo
{
    public class DataClass
    {
        public static DemodemodbContext context = new DemodemodbContext();

        public DataClass() { }

        public static User Auth(string login, string paswword)
        {
            return context.Users.Include(u => u.IdRoleNavigation).FirstOrDefault(u => u.Login == login && u.Password == paswword);
        }

        public static List<Product> GetProducts()
        {
            return context.Products.Include(p => p.IdManufacturerNavigation).Include(p => p.IdDeliverNavigation).Include(p => p.IdCaregoryNavigation).ToList();
        }

        public static List<Manufacturer> GetManufacturers()
        {
            return context.Manufacturers.ToList();
        }

        public static List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public static List<Deliver> GetDelivers()
        {
            return context.Delivers.ToList();
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении продукта");
            }
        }

        public static void EditProduct(Product product)
        {
            try
            {
                var edityProduct = context.Products.FirstOrDefault(p => p.IdProduct == product.IdProduct);
                if (edityProduct != null)
                {
                    context.Entry(edityProduct).CurrentValues.SetValues(product);
                    context.SaveChanges();
                } 
                else
                {
                    MessageBox.Show("Товара с таким артикулом нет");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении продукта");
            }
        }

        public static bool AddProduct(Product product)
        {
            try
            {
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
    }
}
