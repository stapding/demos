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
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public static Product editableProduct { get; set; }
        public EditProductPage(Product product)
        {
            InitializeComponent();
            editableProduct = product;
            LoadComboBoxes();

            nameTB.Text = product.Name;
            unitTB.Text = product.Unit;
            priceTB.Text = product.Price.ToString();
            maxSaleTB.Text = product.MaxSale.ToString();
            manufacturerCB.SelectedValue = product.IdManufacturer;
            deliverCB.SelectedValue = product.IdDeliver;
            categoryCB.SelectedValue = product.IdCaregory;
            currentSaleTB.Text = product.CurrentSale.ToString();
            quantityTB.Text = product.Quantity.ToString();
            descriptionTB.Text = product.Description;
            imageTB.Text = product.Image;
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

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTB.Text) || string.IsNullOrEmpty(unitTB.Text) || string.IsNullOrEmpty(descriptionTB.Text))
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
                IdProduct = editableProduct.IdProduct,
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

            DataClass.EditProduct(product);
            MessageBox.Show($"Продукт {editableProduct.IdProduct} успешно изменен");
            NavigationService?.Navigate(new ProductsPage());
        }
    }
}
