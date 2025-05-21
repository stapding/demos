using demodemo.Models;
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

namespace demodemo
{
    /// <summary>
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        public AgentsPage()
        {
            InitializeComponent();
            ListViewAgents.ItemsSource = DataClass.GetAgents();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddAgentPage());
        }

        private void Refresh()
        {
            ListViewAgents.ItemsSource = null;
            ListViewAgents.ItemsSource = DataClass.GetAgents();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAgent = ListViewAgents.SelectedItem as Agent;
            if (selectedAgent != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить агента?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    DataClass.DeleteAgent(selectedAgent);
                    Refresh();
                    MessageBox.Show("Агент успешно удалён");
                }
            }
            else
            {
                MessageBox.Show("Выберите агента в списке");
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedAgent = ListViewAgents.SelectedItem as Agent;
            if (selectedAgent != null)
            {
                NavigationService.Navigate(new EditAgentPage(selectedAgent));
            }
            else
            {
                MessageBox.Show("Выберите агента в списке");
            }
        }
    }
}
