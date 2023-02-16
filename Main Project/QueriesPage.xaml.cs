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
    /// Логика взаимодействия для QueriesPage.xaml
    /// </summary>
    public partial class QueriesPage : Page
    {
        DBLearningMath dBLearningMath = new DBLearningMath();

        public QueriesPage()
        {
            InitializeComponent();
        }

        private void ClickButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }

        private void ClickButtonExecute(object sender, RoutedEventArgs e)
        {
            if(textboxQuery.Text != "")
            {
                textboxQuery.Visibility = Visibility.Hidden;
                buttonExecute.Visibility = Visibility.Hidden;
                queriesDataGrid.Visibility = Visibility.Visible;

                string query = textboxQuery.Text;

                dBLearningMath.OpenConnection();

                SqlCommand stats_command = new SqlCommand(query, dBLearningMath.GetConnection());

                stats_command.ExecuteNonQuery();
                SqlDataAdapter statsDataAdapter = new SqlDataAdapter(stats_command);
                DataTable dataTable = new DataTable("Статистика");
                statsDataAdapter.Fill(dataTable);
                queriesDataGrid.ItemsSource = dataTable.DefaultView;

                dBLearningMath.CloseConnection();

            }
        }
    }
}
