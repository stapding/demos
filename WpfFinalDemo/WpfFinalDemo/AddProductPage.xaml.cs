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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            manufacturerCB.ItemsSource = DataClass.GetManufacturers();
            manufacturerCB.DisplayMemberPath = "Name";
            manufacturerCB.SelectedValuePath = "IdManufacturer";
            manufacturerCB.SelectedIndex = 0;

            deliverCB.ItemsSource = DataClass.GetDelivers();
            deliverCB.DisplayMemberPath = "Name";
            deliverCB.SelectedValuePath = "IdDeliver";
            deliverCB.SelectedIndex = 0;

            categoryCB.ItemsSource = DataClass.GetCategories();
            categoryCB.DisplayMemberPath = "Name";
            categoryCB.SelectedValuePath = "IdCategory";
            categoryCB.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(articulTB.Text) || articulTB.Text.Length != 6)
            {
                MessageBox.Show("Артикул должен иметь 6-и символов");
                return;
            }
            if (string.IsNullOrWhiteSpace(nameTB.Text) || string.IsNullOrWhiteSpace(unitTB.Text) || string.IsNullOrWhiteSpace(descriptionTB.Text))
            {
                MessageBox.Show("Поля с названием, единицей измерения, описанием не должны быть пустыми");
                return;
            }
            if ((!int.TryParse(priceTB.Text, out int price) || price < 0) || (!int.TryParse(maxSaleTB.Text, out int maxSale) || maxSale < 0) || (!int.TryParse(currentSaleTB.Text, out int currentSale) || currentSale < 0) || (!int.TryParse(quantityTB.Text, out int quantity) || quantity < 0))
            {
                MessageBox.Show("Числовые значения должны быть числами и не должы быть отрицательны");
                return;
            }

            var product = new Product
            {
                IdProduct = articulTB.Text,
                Name = nameTB.Text,
                Unit = unitTB.Text,
                Price = price,
                MaxSale = maxSale,
                IdManufacturer = (int)manufacturerCB.SelectedValue,
                IdDeliver = (int)deliverCB.SelectedValue,
                IdCaregory = (int)categoryCB.SelectedValue,
                CurrentSale = currentSale,
                Quantity = quantity,
                Description = descriptionTB.Text,
                Image = imageTB.Text
            };

            if (DataClass.AddProduct(product))
            {
                MessageBox.Show("Продукт успешно добавлен");
                NavigationService.Navigate(new ProductsPage());
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении товара");
            }
        }
    }
}
