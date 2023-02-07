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
        static private string dbName;

        static DBLearningMath()
        {
            if(Environment.MachineName == "IVAN")
                dbName = @"IVAN\SQLEXPRESS01";
            else
                dbName= @"I9-PC\SQLEXPRESS";
        }

        SqlConnection sqlConnection = new SqlConnection($@"Server = {dbName}; Database = LearningMath; Trusted_Connection = True;");

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
