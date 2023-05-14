using System;
using System.Collections.Generic;
using System.Globalization;
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
        DemoAppDbEntities dbmodel = new DemoAppDbEntities();
        List<Agent> agentList = new List<Agent>();

        public MainWindow()
        {
            InitializeComponent();
            agentList = dbmodel.Agent.ToList();
            AgentList.ItemsSource = agentList;
            Filter1.ItemsSource = new List<string>()
            {
                "Имя","Приоритет","Размер скидки"
            };
            Filter2.ItemsSource = new List<string>
            {
                "По возрастанию", "По убыванию"
            };
            DiscountCount();
            PictureInit();
            updateRecordAmount();
        }

        private void updateRecordAmount()
        {
            RecordAmountLabel.Content = $"{AgentList.Items.Count} из {agentList.Count}";
        }

        private void PictureInit()
        {
            foreach (Agent agent in agentList)
            {
                agent.Logo = $"Resources{agent.Logo}";
                foreach (CompanyType companyType in dbmodel.CompanyType)
                {
                    if (agent.CompanyTypeId == companyType.CompanyTypeId)
                    {
                        agent.CompanyType = companyType;
                    }
                }
            }
        }

        private void DiscountCount()
        {
            int i = 1;
            foreach (Agent agent in agentList)
            {
                double discount = (double)agent.TotalImplementation * 10;
                agent.TIN = discount + "%";
            }
        }

        private void Filter1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agentList = dbmodel.Agent.ToList();
            switch (Filter1.SelectedIndex)
            {
                case 0:
                    {
                        AgentList.ItemsSource = agentList.OrderBy(p => p.Name);
                        break;
                    }
                case 1:
                    {
                        AgentList.ItemsSource = agentList.OrderBy(p => p.Priority);
                        break;
                    }
                case 2:
                    {
                        AgentList.ItemsSource = agentList.OrderBy(p => p.TotalImplementation);
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
            agentList = dbmodel.Agent.ToList();
            switch (Filter1.SelectedIndex)
            {
                case 0:
                    {
                        if(Filter1.SelectedIndex == 0)
                            AgentList.ItemsSource = agentList.OrderBy(p => p.Name);
                        else if(Filter1.SelectedIndex == 1)
                            AgentList.ItemsSource = agentList.OrderBy(p => p.Priority);
                        else if (Filter1.SelectedIndex == 2)
                            AgentList.ItemsSource = agentList.OrderBy(p => p.TotalImplementation);
                        break;
                    }
                case 1:
                    {
                        if (Filter1.SelectedIndex == 0)
                            AgentList.ItemsSource = agentList.OrderByDescending(p => p.Name);
                        else if (Filter1.SelectedIndex == 1)
                            AgentList.ItemsSource = agentList.OrderByDescending(p => p.Priority);
                        else if (Filter1.SelectedIndex == 2)
                            AgentList.ItemsSource = agentList.OrderByDescending(p => p.TotalImplementation);
                        break;
                    }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var elements = AgentList.SelectedItems.Cast<Agent>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {elements.Count} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    dbmodel.Agent.RemoveRange(elements);
                    dbmodel.SaveChanges();
                    MessageBox.Show("Данные удалены!", "Окно оповещений");
                    AgentList.ItemsSource = dbmodel.Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(AgentList.SelectedItem as Agent);
            editWindow.Show();
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(new Agent());
            addWindow.Show();
            Close();
        }
    }
}
