using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.IO;
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
using System.Windows.Shapes;

namespace DemoApp2
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        DemoAppDbEntities dbmodel = new DemoAppDbEntities();
        MainWindow mainWindow = new MainWindow();
        Agent _currentAgent;
        public EditWindow(Agent agent)
        {
            InitializeComponent();
            _currentAgent = agent;
            DataInitMethod();
            InitImage();
        }
        private void DataInitMethod()
        {
            if (_currentAgent != null)
            {
                NameTextBox.Text = _currentAgent.Name;
                PhoneTextBox.Text = _currentAgent.Phone;
                EmailTextBox.Text = _currentAgent.Email;
                LegalAddressTextBox.Text = _currentAgent.LegalAddress;
                PriorityTextBox.Text = Convert.ToString(_currentAgent.Priority);
                PrincipalTextBox.Text = _currentAgent.Principal;
                TINTextBox.Text = _currentAgent.TIN;
                KPPTextBox.Text = _currentAgent.KPP;
                TotalImplementationTextBox.Text = Convert.ToString(_currentAgent.TotalImplementation);
                CompanyTypeIdTextBox.Text = Convert.ToString(_currentAgent.CompanyTypeId);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(NameTextBox.Text))
                MessageBox.Show("Введите наименование!", "Ошибка");
            if (string.IsNullOrEmpty(LegalAddressTextBox.Text))
                MessageBox.Show("Введите Юр. адрес!", "Ошибка");
            if (string.IsNullOrEmpty(PriorityTextBox.Text))
                MessageBox.Show("Введите приоритет!", "Ошибка");
            if (string.IsNullOrEmpty(TINTextBox.Text))
                MessageBox.Show("Введите ИНН!", "Ошибка");
            if (string.IsNullOrEmpty(KPPTextBox.Text))
                MessageBox.Show("Введите КПП!", "Ошибка");
            if (string.IsNullOrEmpty(PrincipalTextBox.Text))
                MessageBox.Show("Введите полное имя директора!", "Ошибка");
            if (string.IsNullOrEmpty(TotalImplementationTextBox.Text))
                MessageBox.Show("Введите полную сумму!", "Ошибка");
            if (string.IsNullOrEmpty(CompanyTypeIdTextBox.Text))
                MessageBox.Show("Введите Id типа компании!", "Ошибка");
            if (Convert.ToInt16(CompanyTypeIdTextBox.Text) < 2 || Convert.ToInt16(CompanyTypeIdTextBox.Text) > 7)
                MessageBox.Show("Идентификатор типа компании начинается с 2, максимальное значение - 7!", "Ошибка");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            using (var dbmodel = new DemoAppDbEntities())
            {
                _currentAgent.Name = NameTextBox.Text;
                _currentAgent.Email = EmailTextBox.Text;
                _currentAgent.Phone = PhoneTextBox.Text;
                _currentAgent.LegalAddress = LegalAddressTextBox.Text;
                _currentAgent.Priority = Convert.ToInt16(PriorityTextBox.Text);
                _currentAgent.Principal = PrincipalTextBox.Text;
                _currentAgent.TIN = TINTextBox.Text;
                _currentAgent.KPP = KPPTextBox.Text;
                _currentAgent.TotalImplementation = Convert.ToDouble(TotalImplementationTextBox.Text);
                _currentAgent.CompanyTypeId = Convert.ToInt16(CompanyTypeIdTextBox.Text);
                try
                {
                    dbmodel.Agent.AddOrUpdate(_currentAgent);
                    dbmodel.SaveChanges();
                    MessageBox.Show("Информация успешно добавлена!", "Окно оповещений");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
            Close();
        }

        private void InitImage()
        {
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            try
            {
                if (_currentAgent != null)
                {
                    imageSource.UriSource = new Uri(@"/DemoApp;component" + _currentAgent.Logo);
                    BitmapImage picture = new BitmapImage();
                    picture.BeginInit();
                    picture.UriSource = new Uri(@"/DemoApp;component/Resources/", UriKind.Relative);
                    if (imageSource.UriSource == picture.UriSource)
                    {
                        imageSource.UriSource = new Uri(@"/DemoApp;component/Resources/picture.png", UriKind.Relative);
                    }
                }
                else
                    imageSource.UriSource = new Uri(@"/DemoApp;component/Resources/picture.png");
            }
            catch
            {
                return;
            }
            imageSource.EndInit();
            Picture.Source = imageSource;
        }

        private void ImageButoon_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true)
            {
                string filename = ofd.FileName;
                string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fileInfo = new FileInfo(currentDir);
                DirectoryInfo dirInfo = fileInfo.Directory.Parent;
                string parentDirName = dirInfo.Name;

                fileInfo = new FileInfo(parentDirName);
                dirInfo = fileInfo.Directory.Parent;
                parentDirName = dirInfo.Name;

                fileInfo = new FileInfo(dirInfo.ToString());
                dirInfo = fileInfo.Directory.Parent;
                parentDirName = dirInfo.ToString() + "\\Resources\\" + ofd.SafeFileName;
                System.IO.File.Copy(filename, parentDirName);

                _currentAgent.Logo = ofd.SafeFileName;
                dbmodel.Entry(_currentAgent).State = EntityState.Modified;
                dbmodel.SaveChanges();

                InitImage();
            }
        }
    }
}
