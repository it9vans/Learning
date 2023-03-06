using System.Windows;
using System.Windows.Navigation;

namespace Main_Project
{
    //главное окно
    //может содержать в себе TheoryPage, PracticePage, MenuPage + управлние для меню
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MenuPage();
            buttonAccount.Content = Account.Login;
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void ClickButtonResults(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ResultsPage();
        }

        //private void ClickButtonQueries(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Content = new QueriesPage();
        //}

        private void ClickButtonAccount(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Этот раздел находится в разработке!");
        }

        private void ClickButtonMenu(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MenuPage();
        }
    }
}