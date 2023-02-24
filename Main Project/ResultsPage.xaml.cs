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
        DBLearningMath dblearningmath = new DBLearningMath();

        public ResultsPage()
        {
            InitializeComponent();
            ResultsUpdate();
        }

        public void ResultsUpdate()
        {
            string login_check_query = $"SELECT COUNT(login) FROM users WHERE login = '{Account.Login}'";
            string resultsQuery;
            if (Account.Acc_type == "student")
            {
                resultsQuery = $"SELECT res_id AS '№', theme AS 'Тема', score AS 'Результат' FROM results WHERE stud_id = (SELECT user_id FROM users WHERE login = '{Account.Login}')";
            }
            else resultsQuery = $"SELECT res_id AS '№', login as 'Логин', theme AS 'Тема', score AS 'Результат' FROM results JOIN users ON results.stud_id=users.user_id;";

            //определяем метод для события(ConnectionNotify), срабатывающего при подключении к бд
            dblearningmath.ConnectionNotify += CommonMethods.GetConnectionStatus;

            dblearningmath.OpenConnection();

            SqlCommand resultsCommand = new SqlCommand(resultsQuery, dblearningmath.GetConnection());

            
            //resultsCommand.ExecuteNonQuery();
            //выполняем команду через DataAdapter
            SqlDataAdapter resultsDataAdapter = new SqlDataAdapter(resultsCommand);
            //создаем таблицу результатов
            DataTable dataTable = new DataTable("Результаты");
            //заполняем таблицу
            resultsDataAdapter.Fill(dataTable);
            //делаем таблицу видимой (здесь не имеет смысла, тк таблицу видна сразу)
            resultsDataGrid.ItemsSource = dataTable.DefaultView;

            dblearningmath.CloseConnection();
        }

        private void ClickButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}
