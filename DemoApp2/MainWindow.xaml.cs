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

namespace DemoApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DemoAppBdEntities dbmodel = new DemoAppBdEntities();
        List<Agent> agentList = new List<Agent>();
        public MainWindow()
        {
            InitializeComponent();
            Filter2.ItemsSource = new List<string>()
            {
                "Имя","Размер скидки","Приоритет"
            };
            Filter1.ItemsSource = new List<string>
            {
                "По возрастанию", "По убыванию"
            };
            using (DemoAppBdEntities context = new DemoAppBdEntities())
            {
                var items = context.Agent.ToList();
                AgentList.ItemsSource = items;
            }
        }

        private void Filter1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agentList = dbmodel.Agent.ToList();
            switch (Filter1.SelectedIndex)
            {
                case 0:
                    {
                        AgentList.ItemsSource = agentList.OrderBy(p => p.Priority);
                        break;
                    }
                case 1:
                    {
                        AgentList.ItemsSource = agentList.OrderByDescending(p => p.Priority);
                        break;
                    }
            }
        }
        private void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            agentList = agentList.Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            AgentList.ItemsSource = agentList;
        }

        private void Filter2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
