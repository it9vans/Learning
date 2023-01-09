using System.Windows;

namespace Main_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_TheoryButton(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Theory theory = new Theory();
            theory.Show();
        }

        private void Click_PracticeButton(object sender, RoutedEventArgs e)
        {
            Practice practice = new Practice();
            this.Hide();
            practice.Show();
        }
    }
}