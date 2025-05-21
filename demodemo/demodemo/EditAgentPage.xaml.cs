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
    /// Логика взаимодействия для EditAgentPage.xaml
    /// </summary>
    public partial class EditAgentPage : Page
    {
        public static Agent edityAgent { get; set; }
        public EditAgentPage(Agent agent)
        {
            InitializeComponent();
            edityAgent = agent;
            LoadCombos();

            typeCB.SelectedValue = agent.IdAgentType;
            addressCB.SelectedValue = agent.IdAddress;
            directorCB.SelectedValue = agent.IdDirector;
            nameTB.Text = agent.Name;
            emailTB.Text = agent.Email;
            phoneTB.Text = agent.Phone;
            logoTB.Text = agent.Logo;
            priorityTB.Text = agent.Priority.ToString();
            innTB.Text = agent.Inn;
            kppTB.Text = agent.Kpp;
        }

        private void LoadCombos()
        {
            directorCB.ItemsSource = DataClass.GetDirectors();
            directorCB.DisplayMemberPath = "MiddleName";
            directorCB.SelectedValuePath = "IdDirector";

            typeCB.ItemsSource = DataClass.GetAgentTypes();
            typeCB.DisplayMemberPath = "Name";
            typeCB.SelectedValuePath = "IdAgentType";

            addressCB.ItemsSource = DataClass.GetAddresses();
            addressCB.DisplayMemberPath = "Street";
            addressCB.SelectedValuePath = "IdAddress";
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var agent = new Agent
            {
                IdAgent = edityAgent.IdAgent,
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

            DataClass.EditAgent(agent);
            MessageBox.Show("Изменение агента прошло успешно");
            NavigationService?.Navigate(new AgentsPage());
        }
    }
}
