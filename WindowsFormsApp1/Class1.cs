using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Class1
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-GCUHU5B;Initial Catalog=Terminal;Integrated Security=True");
        public void openConnection()/*Открывает связь с БД*/
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()/*Закрывает связь с БД*/
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()/*Возвращает строку подключения*/
        {
            return sqlConnection;
        }
    }
}
