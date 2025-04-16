using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDEMO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new LoginPage());
        }

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (mainFrame.Content is LoginPage) // Замени на актуальное имя страницы авторизации
            {
                stackButtons.Visibility = Visibility.Collapsed;
                currentWindow.Title = "Цветы | Авторизация";
            }
            else if (mainFrame.Content is ProductsPage) // Замени на актуальное имя страницы авторизации
            {
                stackButtons.Visibility = Visibility.Visible;
                currentWindow.Title = "Цветы | Список продуктов";
            }
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new LoginPage());
        }
    }
}