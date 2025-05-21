using demodemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для AddAgentPage.xaml
    /// </summary>
    public partial class AddAgentPage : Page
    {
        public AddAgentPage()
        {
            InitializeComponent();
            LoadCombos();
        }

        private void LoadCombos()
        {
            directorCB.ItemsSource = DataClass.GetDirectors();
            directorCB.DisplayMemberPath = "MiddleName";
            directorCB.SelectedValuePath = "IdDirector";
            directorCB.SelectedIndex = 0;

            typeCB.ItemsSource = DataClass.GetAgentTypes();
            typeCB.DisplayMemberPath = "Name";
            typeCB.SelectedValuePath = "IdAgentType";
            typeCB.SelectedIndex = 0;

            addressCB.ItemsSource = DataClass.GetAddresses();
            addressCB.DisplayMemberPath = "Street";
            addressCB.SelectedValuePath = "IdAddress";
            addressCB.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(addressCB.SelectedIndex.ToString());
            var agent = new Agent
            {
                IdAgentType = (int)typeCB.SelectedValue,
                Name = nameTB.Text,
                Email = emailTB.Text,
                Phone = phoneTB.Text,
                Logo = logoTB.Text,
                IdAddress = (int)addressCB.SelectedValue,
                Priority = int.Parse(priorityTB.Text),
                IdDirector = (int)directorCB.SelectedValue,
                Inn = innTB.Text,
                Kpp = kppTB.Text
            };

            if (DataClass.AddAgent(agent))
            {
                MessageBox.Show("Агент успешно добавлен");
                NavigationService?.Navigate(new AgentsPage());
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении агента");
            }
        }
    }
}
