using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDEMO.Models;

namespace WpfDEMO
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            LoadProducts(); // Загружаем продукты при открытии страницы
            if (Session.CurrentUser.IdRoleNavigation.Name != "Администратор")
            {
                stackButtons.Visibility = Visibility.Collapsed;
            }
        }

        private void LoadProducts()
        {
            var products = DataClass.GetProducts();
            ListProducts.ItemsSource = products;
        }

        private void RefreshProducts()
        {
            ListProducts.ItemsSource = null;
            ListProducts.ItemsSource = DataClass.GetProducts();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddProductPage());
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ListProducts.SelectedItem as Product;

            if (selectedProduct == null)
            {
                MessageBox.Show("Пожалуйста, выберите продукт для удаления.");
                return;
            }

            var result = MessageBox.Show($"Вы точно хотите удалить продукт: {selectedProduct.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                DataClass.DeleteProduct(selectedProduct);
                RefreshProducts();
                MessageBox.Show("Продукт успешно удалён.");
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ListProducts.SelectedItem as Product;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар для редактирования.");
                return;
            }

            NavigationService.Navigate(new EditProductPage(selectedProduct));
        }

        private void ordersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new OrdersPage());
        }
    }
}
