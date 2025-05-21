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

namespace demodemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var lists = DataClass.GetAgents();
            mainFrame.Navigate(new AgentsPage());
        }

        private void mainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!mainFrame.CanGoBack)
            {
                backButton.Visibility = Visibility.Collapsed;
            } else
            {
                backButton.Visibility = Visibility.Visible;
            }

            if (mainFrame.Content is AgentsPage)
            {
                mainWindow.Title = "Глазки-save | Список продуктов";
            }
            else if (mainFrame.Content is AddAgentPage)
            {
                mainWindow.Title = "Глазки-save | Добавление агента";
            } else if (mainFrame.Content is EditAgentPage)
            {
                mainWindow.Title = "Глазки-save | Изменение агента";
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.GoBack();
        }
    }
}