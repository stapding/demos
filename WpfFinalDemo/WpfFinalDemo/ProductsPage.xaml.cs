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
using WpfFinalDemo.Models;

namespace WpfFinalDemo
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private List<Product> _allProducts;

        public ProductsPage()
        {
            InitializeComponent();
            _allProducts = DataClass.GetProducts();
            ApplyFilters();

            if (Session.CurrentUser.IdRoleNavigation.Name != "Администратор")
            {
                stackButtons.Visibility = Visibility.Collapsed;
            }

            searchTB.TextChanged += Filter_Changed;
            sortCB.SelectionChanged += Filter_Changed;
            filterCB.SelectionChanged += Filter_Changed;
        }

        private void ApplyFilters()
        {
            var filtered = _allProducts;

            // Поиск
            string searchText = searchTB.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filtered = filtered
                    .Where(p => p.Name.ToLower().Contains(searchText))
                    .ToList();
            }

            // Фильтр по скидке
            switch (filterCB.SelectedIndex)
            {
                case 0: // 0-9.99%
                    filtered = filtered.Where(p => p.CurrentSale < 10).ToList();
                    break;
                case 1: // 10-14.99%
                    filtered = filtered.Where(p => p.CurrentSale >= 10 && p.CurrentSale < 15).ToList();
                    break;
                case 2: // 15% и более
                    filtered = filtered.Where(p => p.CurrentSale >= 15).ToList();
                    break;
            }

            // Сортировка по цене
            switch (sortCB.SelectedIndex)
            {
                case 0: // По убыванию
                    filtered = filtered.OrderByDescending(p => p.Price).ToList();
                    break;
                case 1: // По возрастанию
                    filtered = filtered.OrderBy(p => p.Price).ToList();
                    break;
            }

            counterTB.Text = $"{filtered.Count} из {DataClass.GetProducts().Count}";

            ListViewProducts.ItemsSource = filtered;
        }
        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddProductPage());
        }

        private void Refresh()
        {
            _allProducts = DataClass.GetProducts();
            ApplyFilters();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ListViewProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот товар?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    DataClass.DeleteProduct(selectedProduct);
                    Refresh();
                    MessageBox.Show($"Продукт {selectedProduct.IdProduct} был успешно удалён");
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления");
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ListViewProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                NavigationService?.Navigate(new EditProductPage(selectedProduct));
            }
            else
            {
                MessageBox.Show("Выберите продукт для изменения");
            }
        }
    }
}
