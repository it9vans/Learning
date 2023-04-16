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
        //имя сервера, меняется в зависмости от машины, на которой запускается программа
        static private string serverName;
        //делегат для события, срабатывающего при подклюении к бд
        public delegate void ConnectionHandler(string message);
        //событие для отправки состояния подключения
        public event ConnectionHandler ConnectionNotify;

        //инициализируем имя сервера
        static DBLearningMath()
        {
            if(Environment.MachineName == "IVAN")
                serverName = @"IVAN\SQLEXPRESS";
            else
                serverName= @"I9-PC\SQLEXPRESS";
        }

        SqlConnection sqlConnection = new SqlConnection($@"Server = {serverName}; Database = LearningMath; Trusted_Connection = True;");

        public void OpenConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
                ConnectionNotify.Invoke("Connection is opened");
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
                ConnectionNotify.Invoke("Connection is closed");
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
