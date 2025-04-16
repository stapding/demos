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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void LoadComboBoxes()
        {
            manufacturerComboBox.ItemsSource = DataClass.GetManufacturers();
            manufacturerComboBox.DisplayMemberPath = "Name"; // или другое свойство
            manufacturerComboBox.SelectedValuePath = "IdManufacturer";   // или другое свойство

            deliverComboBox.ItemsSource = DataClass.GetDelivers();
            deliverComboBox.DisplayMemberPath = "Name"; // или другое свойство
            deliverComboBox.SelectedValuePath = "IdDeliver"; // или другое свойство

            categoryComboBox.ItemsSource = DataClass.GetCategories();
            categoryComboBox.DisplayMemberPath = "Name"; // или другое свойство
            categoryComboBox.SelectedValuePath = "IdCategory";   // или другое свойство
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(articulBox.Text) || articulBox.Text.Length != 6)
                {
                    MessageBox.Show("Введите корректный артикул (6 символов)");
                    return;
                }
                if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrWhiteSpace(unitBox.Text) || string.IsNullOrWhiteSpace(unitBox.Text) || string.IsNullOrWhiteSpace(descriptionBox.Text))
                {
                    MessageBox.Show("Поля с названием, артикулем, именем, единицей измерения, описанием должны быть заполнены");
                    return;
                }
                if (manufacturerComboBox.SelectedValue == null || deliverComboBox.SelectedValue == null || categoryComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Пожалуйста, выберите производителя, поставщика и категорию.");
                    return;
                }

                // Парсим числовые значения и проверяем отрицательные
                if ((!int.TryParse(costBox.Text, out int cost) || cost < 0) || (!int.TryParse(maxSaleBox.Text, out int maxSale) || maxSale < 0) || (!int.TryParse(currentSaleBox.Text, out int currentSale) || currentSale < 0) || (!int.TryParse(quantityBox.Text, out int quantity) || quantity < 0))
                {
                    MessageBox.Show("Введите корректные (неотрицательные) числовые значения.");
                    return;
                }

                var product = new Product
                {       
                    IdProduct = articulBox.Text,
                    Name = nameBox.Text,
                    Unit = unitBox.Text,
                    Cost = cost,
                    MaxSale = maxSale,
                    IdManufacturer = (int?)manufacturerComboBox.SelectedValue,
                    IdDeliver = (int?)deliverComboBox.SelectedValue,
                    IdCategory = (int?)categoryComboBox.SelectedValue,
                    CurrentSale = currentSale,
                    Quantity = quantity,
                    Description = descriptionBox.Text,
                    Image = imageBox.Text
                };

                if (DataClass.AddProduct(product))
                {
                    MessageBox.Show("Товар успешно добавлен!");
                    NavigationService?.Navigate(new ProductsPage());
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
