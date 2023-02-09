﻿using System;
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

        void OnLoad(object sender, RoutedEventArgs e)
        {

        }



        private void ClickButtonLogin(object sender, RoutedEventArgs e)
        {
            string login = textbox_login.Text;
            string password = PasswordBoxMain.Password.ToString();
            string loginQuery = $"select count(login) from users where login = '{login}' and passw = '{password}';";
            string accTypeQuery = $"select acc_type from users where login = '{login}';";


            dBlearningmath.OpenConnection();
            SqlCommand command = new SqlCommand(loginQuery, dBlearningmath.GetConnection());

            if (Convert.ToInt32(command.ExecuteScalar()) != 1)
                MessageBox.Show("Неправильный логин/пароль. Попробуйте снова.");
            else
            {
                command.CommandText = accTypeQuery;
                Account.login = login;
                Account.acc_type = Convert.ToString(command.ExecuteScalar());
                Application.Current.MainWindow.Hide();
                MainWindow mainWindow= new MainWindow();
                mainWindow.Show();
            }
            dBlearningmath.CloseConnection();
        }
    }
}
