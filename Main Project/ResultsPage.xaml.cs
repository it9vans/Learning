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

        private void ClickBackButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        public void ResultsUpdate()
        {
            string login_check_query = $"SELECT COUNT(login) FROM users WHERE login = '{Account.login}'";
            string stats_query = $"SELECT res_id AS '№', theme AS 'Тема', score AS 'Результат' FROM results WHERE stud_id = (SELECT user_id FROM users WHERE login = '{Account.login}')";

            dBLearningMath.OpenConnection();

            SqlCommand login_check_command = new SqlCommand(login_check_query, dBLearningMath.GetConnection());
            SqlCommand stats_command = new SqlCommand(stats_query, dBLearningMath.GetConnection());

            if (Convert.ToInt32(login_check_command.ExecuteScalar()) == 1)
            {
                stats_command.ExecuteNonQuery();
                SqlDataAdapter statsDataAdapter = new SqlDataAdapter(stats_command);
                DataTable dataTable = new DataTable("Статистика");
                statsDataAdapter.Fill(dataTable);
                resultsDataGrid.ItemsSource = dataTable.DefaultView;
            }

            else
            {
                MessageBox.Show("У вас пока нет результатов!");                
            }

           dBLearningMath.CloseConnection();
        }
    }
}
