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

namespace VisualDemoex
{
    /// <summary>
    /// Логика взаимодействия для Agents.xaml
    /// </summary>
    public partial class Agents : Page
    {
        public Agents()
        {
            InitializeComponent();
            AgentList.ItemsSource = Db.demoForVisualEntities.Agent.ToList();
            CbFilter.Items.Add("Все типы");
            foreach (var agentType in Db.demoForVisualEntities.AgentType)
            {
                CbFilter.Items.Add(agentType.Title);
            }
            CbFilter.SelectedIndex = 0;

            CbSort.Items.Add("Сортировка");
            CbSort.Items.Add("От А до Я");
            CbSort.Items.Add("От Я до А");
            CbSort.SelectedIndex = 0;

            switch (CbSort.SelectedIndex)
            {
                case 0: 
                    break;
                case 1:
                    AgentList.ItemsSource = Db.demoForVisualEntities.Agent.OrderBy(x => x.Title.ToList());
                    break;
                case 2:
                    AgentList.ItemsSource = Db.demoForVisualEntities.Agent.OrderByDescending(x => x.Title);
                    break;
                default:
                    break;
            }
            
        }
        /// <summary>
        /// Сортировка по буквам вводимых пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindAgents();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Admin.MainFrame.Navigate(new AgentAdd(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
           // Admin.MainFrame.Navigate(new AgentAdd());
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данные." + "\n" + "Предупреждение", "Вы уверены?", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Вы удалили запись!");
            }
        }

        private void FindAgents()
        {
            List<Agent> agents = Db.demoForVisualEntities.Agent.Where(x => x.Title.StartsWith(TextSearch.Text)).ToList();

            switch(CbSort.SelectedIndex)
            {
                case 0:; break;
                case 1: agents = agents.OrderBy(x => x.Title).ToList(); break;
                case 2: agents = agents.OrderByDescending(x => x.Title).ToList(); break;
            }


            if (CbFilter.SelectedIndex > 0)
            {
                string agentType = CbFilter.SelectedItem.ToString();
                agents = agents.Where(x => x.AgentType.Title == agentType).ToList();
            }

            AgentList.ItemsSource = agents;
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindAgents();
        }

        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindAgents();
        }
    }
}
