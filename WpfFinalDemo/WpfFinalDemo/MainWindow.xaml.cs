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

namespace WpfFinalDemo
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
            if (!mainFrame.CanGoBack)
            {
                backButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                backButton.Visibility = Visibility.Visible;
            }

            if (mainFrame.Content is LoginPage)
            {
                mainWindow.Title = "Украшения | Авторизация";
            }
            else if (mainFrame.Content is ProductsPage)
            {
                mainWindow.Title = "Украшения | Список продуктов";
            }
            else if (mainFrame.Content is AddProductPage)
            {
                mainWindow.Title = "Украшения | Добавление продукта";
            }
            else if (mainFrame.Content is EditProductPage)
            {
                mainWindow.Title = "Украшения | Изменение продукта";
            }
            else
            {
                mainWindow.Title = "Украшения | Список заказов";
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
            }
        }
    }
}