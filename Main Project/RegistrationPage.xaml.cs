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
        readonly DBLearningMath dblearningmath = new DBLearningMath();

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
            //ситываем введенные пользователем данные
            string login = textbox_login.Text;
            string password = textbox_password.Text;
            string passwordcheck = textbox_passwordcheck.Text;
            string surname = textbox_surname.Text;
            string firstName = textbox_firstName.Text;
            string secondName = textbox_secondName.Text;

            //запрос для проверки наличия такого логина + запрос на добавление нового пользователя
            string queryСheck = $"select count(login) from users where login = '{login}';";
            string queryInsert = $"INSERT users VALUES ('{login}', '{password}', 'student', '{surname}', '{firstName}', '{secondName}');";

            //определяем метод для события(ConnectionNotify), срабатывающего при подключении к бд
            dblearningmath.ConnectionNotify += CommonMethods.GetConnectionStatus;

            dblearningmath.OpenConnection();
            SqlCommand command = new SqlCommand(queryСheck, dblearningmath.GetConnection());

            if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                MessageBox.Show("Логин уже используется!");
            else if(password != passwordcheck)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                //после успешной регистрации входим в аккаунт и программу
                command.CommandText = queryInsert; 
                command.ExecuteScalar();
                Account.Login = login;
                Account.Acc_type = "student";
                Application.Current.MainWindow.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            dblearningmath.CloseConnection();
        }
    }
}
