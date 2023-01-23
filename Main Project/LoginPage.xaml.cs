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
using System.Data.SqlClient;

namespace Main_Project
{
    public partial class LoginPage : Page
    {
        DBLearningMath dBlearningmath = new DBLearningMath();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = textbox_login.Text;
            string password = textbox_password.Text;
            string query = $"select count(name_surname) from users where name_surname = '{login}' and passw = '{password}';";



            dBlearningmath.openConnection();
            SqlCommand command = new SqlCommand(query, dBlearningmath.getConnection());

            if (Convert.ToInt32(command.ExecuteScalar()) != 1)
                MessageBox.Show("Неправильный логин/пароль. Попробуйте снова.");
            else
            {
                //Application.Current.MainWindow.Close();
                MainWindow mainWindow= new MainWindow();
                mainWindow.Show();
            }
            dBlearningmath.closeConnection();
        }
    }
}
