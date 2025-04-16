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

namespace WpfFinalDemo
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

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            var user = DataClass.Auth(loginTB.Text, passwordTB.Text);
            if (user != null)
            {
                Session.CurrentUser = user;
                NavigationService?.Navigate(new ProductsPage());
            }
            else
            {
                MessageBox.Show("Ошибка авторизации, проверьте пароль и логин");
            }
        }
    }
}
