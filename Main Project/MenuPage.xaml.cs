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

namespace Main_Project
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        string login;

        public MenuPage(string login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void ClickButtonTheory(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TheoryPage(login));
        }

        private void ClickButtonPractice(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PracticePage(login));
        }
    }
}
