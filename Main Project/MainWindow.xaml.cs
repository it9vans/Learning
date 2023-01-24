using System.Windows;

namespace Main_Project
{
    public partial class MainWindow : Window
    {
        string login;

        public MainWindow(string login)
        {
            InitializeComponent();
            MainFrame.Content = new MenuPage();
            NavigationFrame.Content = new NavigationPage(login);
            this.login = login;
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}