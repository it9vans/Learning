using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// <summary>
    /// Логика взаимодействия для ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        DBLearningMath dBLearningMath = new DBLearningMath();

        public ResultsPage()
        {
            InitializeComponent();
            ResultsUpdate();
        }

        public void ResultsUpdate()
        {
            string login_check_query = $"SELECT COUNT(login) FROM users WHERE login = '{Account.login}'";
            string stats_query;
            if (Account.acc_type == "student")
            {
                stats_query = $"SELECT res_id AS '№', theme AS 'Тема', score AS 'Результат' FROM results WHERE stud_id = (SELECT user_id FROM users WHERE login = '{Account.login}')";
            }
            else stats_query = $"SELECT res_id AS '№', login as 'Логин', theme AS 'Тема', score AS 'Результат' FROM results JOIN users ON results.stud_id=users.user_id;";

            dBLearningMath.OpenConnection();

            SqlCommand stats_command = new SqlCommand(stats_query, dBLearningMath.GetConnection());

            stats_command.ExecuteNonQuery();
            SqlDataAdapter statsDataAdapter = new SqlDataAdapter(stats_command);
            DataTable dataTable = new DataTable("Статистика");
            statsDataAdapter.Fill(dataTable);
            resultsDataGrid.ItemsSource = dataTable.DefaultView;

            dBLearningMath.CloseConnection();
        }

        private void ClickButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}
