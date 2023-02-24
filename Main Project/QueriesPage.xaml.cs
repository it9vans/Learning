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
    //страница для практы по доп запросам для бд, показывает работу с DataGrid
    public partial class QueriesPage : Page
    {
        DBLearningMath dblearningmath = new DBLearningMath();

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

                dblearningmath.OpenConnection();

                SqlCommand resultsCommand = new SqlCommand(query, dblearningmath.GetConnection());

                resultsCommand.ExecuteNonQuery();
                SqlDataAdapter resultsDataAdapter = new SqlDataAdapter(resultsCommand);
                DataTable dataTable = new DataTable("Результаты");
                resultsDataAdapter.Fill(dataTable);
                queriesDataGrid.ItemsSource = dataTable.DefaultView;

                dblearningmath.CloseConnection();

            }
        }
    }
}
