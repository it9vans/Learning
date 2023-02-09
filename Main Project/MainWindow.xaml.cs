using System.Windows;
using System.Windows.Navigation;

namespace Main_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MenuPage();
            buttonAccount.Content = Account.login;
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void ClickButtonResults(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ResultsPage();
        }
    }
}