using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AgentAdd.xaml
    /// </summary>
    public partial class AgentAdd : Page
    {
        Agent agent;
        public AgentAdd(Agent agent)
        {
            InitializeComponent();
            this.agent = agent;
            cbType.ItemsSource = Db.demoForVisualEntities.AgentType.ToList();
        }

        private void CheckAgent()
        {
            ImgLogo.Source = new BitmapImage(new Uri(agent.LogoView, UriKind.Relative));
            tbName.Text = agent.Title;
            tbAddress.Text = agent.Address;
            tbINN.Text = agent.INN;
            tbKPP.Text = agent.KPP;
            tbPhone.Text = agent.Phone;
            tbEmail.Text = agent.Email;
            tbPrio.Text = agent.Priority.ToString();

            if (agent.AgentType == null)
            {
                cbType.SelectedIndex = 0;
            }
            else
            {
                cbType.SelectedItem = agent.AgentType;
            }
        }

        private void btnChangeImg_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данный раздел пока не реализован, у вас поставится фотография по умолчанию", "В разработке");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Agent agent = new Agent();
            try
            {
                agent.Title = tbName.Text;
                agent.Logo = null;
                agent.AgentType = (AgentType)cbType.SelectedItem;
                agent.Address = tbAddress.Text;
                agent.INN = tbINN.Text;
                agent.KPP = tbKPP.Text;
                agent.DirectorName = tbNameDir.Text;
                agent.Phone = tbPhone.Text;
                agent.Email = tbEmail.Text;
                agent.Priority = int.Parse(tbPrio.Text);

                if (tbINN.Text.Length != 10)
                {
                    MessageBox.Show("Инн содержит 10 цифр, проверьте правильность заполнения");
                    return;
                }
                if (tbKPP.Text.Length != 9)
                {
                    MessageBox.Show("Инн содержит 9 цифр, проверьте правильность заполнения");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Какие-то данные не заполнены!", "Предупреждение");
                return;
            }

            if (agent.ID == 0)
            {
                Db.demoForVisualEntities.Agent.Add(agent);
            }
            Db.demoForVisualEntities.SaveChanges();
            Admin.MainFrame.GoBack();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
