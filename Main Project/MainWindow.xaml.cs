using System.Windows;

namespace Main_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MenuPage();
        }
    }
}