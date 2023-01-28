using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Main_Project
{
    internal class DBLearningMath
    {

        SqlConnection sqlConnection = new SqlConnection(@"Server = IVAN\SQLEXPRESS01; Database = LearningMath; Trusted_Connection = True;");

        public void OpenConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
