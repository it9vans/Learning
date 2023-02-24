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
using System.Diagnostics;

namespace Main_Project
{
    public partial class LoginPage : Page
    {
        readonly DBLearningMath dblearningmath = new DBLearningMath();
        

        public LoginPage()
        {
            InitializeComponent();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {

        }



        private void ClickButtonLogin(object sender, RoutedEventArgs e)
        {
            //считываем введеный логин и пароль
            string login = textbox_login.Text;
            string password = PasswordBoxMain.Password.ToString();

            //запросы для проверки логина/пароля + запрос на получение типа аккаунта
            string loginQuery = $"select count(login) from users where login = '{login}' and passw = '{password}';";
            string accTypeQuery = $"select acc_type from users where login = '{login}';";

            //определяем метод для события(ConnectionNotify), срабатывающего при подключении к бд
            dblearningmath.ConnectionNotify += CommonMethods.GetConnectionStatus;

            dblearningmath.OpenConnection();
            SqlCommand command = new SqlCommand(loginQuery, dblearningmath.GetConnection());

            //проверяем на совпадение логина/пароля, если есть совпадение - входим в аккаунт
            if (Convert.ToInt32(command.ExecuteScalar()) != 1)
                MessageBox.Show("Неправильный логин/пароль. Попробуйте снова.");
            else
            {
                command.CommandText = accTypeQuery;
                Account.Login = login;
                Account.Acc_type = Convert.ToString(command.ExecuteScalar()); //считваем из бд тип аккаунта

                //переход на главное окно
                Application.Current.MainWindow.Hide();
                MainWindow mainWindow= new MainWindow();
                mainWindow.Show();
            }
            dblearningmath.CloseConnection();
        }
    }
}
