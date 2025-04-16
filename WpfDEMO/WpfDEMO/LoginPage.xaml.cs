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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = DataClass.Authenticate(loginBox.Text, passwordBox.Text);
            if (currentUser != null)
            {
                MessageBox.Show($"Добро пожаловать, {currentUser.FirstName}!");
                Session.CurrentUser = currentUser;
                NavigationService?.Navigate(new ProductsPage());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
