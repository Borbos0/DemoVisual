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
            CbFilter.Items.Add("По типу");
            CbSort.Items.Add("От А до Я");
            CbSort.Items.Add("От Я до А");
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            AgentList.ItemsSource = Db.demoForVisualEntities.Agent.Where(x => x.Title.StartsWith(TextSearch.Text)).ToList();
        }
    }
}
