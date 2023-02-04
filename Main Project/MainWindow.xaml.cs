using System.Windows;
using System.Windows.Navigation;

namespace Main_Project
{
    public partial class MainWindow : Window
    {
        string login;

        public MainWindow(string login)
        {
            InitializeComponent();
            MainFrame.Content = new MenuPage(login);
            this.login = login;
            buttonAccount.Content = login;
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void ClickButtonResults(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ResultsPage(login);
        }
    }
}