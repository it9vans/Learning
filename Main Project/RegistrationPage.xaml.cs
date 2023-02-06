using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public partial class RegistrationPage : Page
    {
        DBLearningMath dBlearningmath = new DBLearningMath();

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ClickButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void ClickButtonRegister(object sender, RoutedEventArgs e)
        {
            string login = textbox_login.Text;
            string password = textbox_password.Text;
            string passwordcheck = textbox_passwordcheck.Text;
            string queryСheck = $"select count(login) from users where login = '{login}';";
            string queryInsert = $"INSERT users VALUES ('{login}', '{password}', 'student');";

            dBlearningmath.OpenConnection();
            SqlCommand commandCheck = new SqlCommand(queryСheck, dBlearningmath.GetConnection());
            SqlCommand commandInsert = new SqlCommand(queryInsert, dBlearningmath.GetConnection());

            if (Convert.ToInt32(commandCheck.ExecuteScalar()) > 0)
                MessageBox.Show("Логин уже используется!");
            else if(password != passwordcheck)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                commandInsert.ExecuteScalar();
                Application.Current.MainWindow.Hide();
                MainWindow mainWindow = new MainWindow(login);
                mainWindow.Show();
            }
            dBlearningmath.CloseConnection();
        }
    }
}
