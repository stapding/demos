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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private List<Order> allOrders;

        public OrdersPage()
        {
            InitializeComponent();
            OrdersListView.ItemsSource = DataClass.GetOrders();
            LoadOrders();
            LoadPosts();
        }

        private void LoadPosts()
        {
            var posts = DataClass.context.Posts.ToList();
            postsComboBox.Items.Add("Все посты");
            foreach (var post in posts)
            {
                postsComboBox.Items.Add(post);
            }

            postsComboBox.DisplayMemberPath = "Street";
            postsComboBox.SelectedIndex = 0;
            postsComboBox.SelectionChanged += postsComboBox_SelectionChanged;
        }

        private void LoadOrders()
        {
            allOrders = DataClass.GetOrders(); // Метод из DataClass
            FilterOrders();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void postsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterOrders();
        }

        private void FilterOrders()
        {
            if (postsComboBox.SelectedItem is Post selectedPost)
            {
                OrdersListView.ItemsSource = allOrders.Where(o
                    => o.IdPost == selectedPost.IdPost).ToList();
            }
            else
            {
                OrdersListView.ItemsSource = allOrders;
            }
        }
    }
}
