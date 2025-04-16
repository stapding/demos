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
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        private Product editingProduct;

        public EditProductPage(Product product)
        {
            InitializeComponent();
            editingProduct = product;

            manufacturerComboBox.ItemsSource = DataClass.context.Manufacturers.ToList();
            manufacturerComboBox.DisplayMemberPath = "Name";
            manufacturerComboBox.SelectedValuePath = "IdManufacturer";

            deliverComboBox.ItemsSource = DataClass.context.Delivers.ToList();
            deliverComboBox.DisplayMemberPath = "Name";
            deliverComboBox.SelectedValuePath = "IdDeliver";

            categoryComboBox.ItemsSource = DataClass.context.Categories.ToList();
            categoryComboBox.DisplayMemberPath = "Name";
            categoryComboBox.SelectedValuePath = "IdCategory";

            // Заполнение полей
            articulBox.Text = editingProduct.IdProduct;
            nameBox.Text = editingProduct.Name;
            unitBox.Text = editingProduct.Unit;
            costBox.Text = editingProduct.Cost?.ToString();
            maxSaleBox.Text = editingProduct.MaxSale?.ToString();
            manufacturerComboBox.SelectedValue = editingProduct.IdManufacturer;
            deliverComboBox.SelectedValue = editingProduct.IdDeliver;
            categoryComboBox.SelectedValue = editingProduct.IdCategory;
            currentSaleBox.Text = editingProduct.CurrentSale?.ToString();
            quantityBox.Text = editingProduct.Quantity?.ToString();
            descriptionBox.Text = editingProduct.Description;
            imageBox.Text = editingProduct.Image;
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(articulBox.Text) || articulBox.Text.Length != 6)
                {
                    MessageBox.Show("Введите корректный артикул (6 символов)");
                    return;
                }

                if (string.IsNullOrWhiteSpace(nameBox.Text) ||
                    string.IsNullOrWhiteSpace(unitBox.Text) ||
                    string.IsNullOrWhiteSpace(descriptionBox.Text))
                {
                    MessageBox.Show("Поля с названием, единицей измерения и описанием должны быть заполнены.");
                    return;
                }

                if (manufacturerComboBox.SelectedValue == null || deliverComboBox.SelectedValue == null || categoryComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Пожалуйста, выберите производителя, поставщика и категорию.");
                    return;
                }

                editingProduct.Name = nameBox.Text;
                editingProduct.Unit = unitBox.Text;
                editingProduct.Cost = int.TryParse(costBox.Text, out var cost) ? cost : 0;
                editingProduct.MaxSale = int.TryParse(maxSaleBox.Text, out var maxSale) ? maxSale : 0;
                editingProduct.IdManufacturer = manufacturerComboBox.SelectedValue as int?;
                editingProduct.IdDeliver = deliverComboBox.SelectedValue as int?;
                editingProduct.IdCategory = categoryComboBox.SelectedValue as int?;
                editingProduct.CurrentSale = int.TryParse(currentSaleBox.Text, out var currSale) ? currSale : 0;
                editingProduct.Quantity = int.TryParse(quantityBox.Text, out var qty) ? qty : 0;
                editingProduct.Description = descriptionBox.Text;
                editingProduct.Image = imageBox.Text;

                DataClass.UpdateProduct(editingProduct); // метод в DataClass

                MessageBox.Show("Товар успешно обновлён!");
                NavigationService.Navigate(new ProductsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении товара: " + ex.Message);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
