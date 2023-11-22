using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace UP__
{
    internal class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = ZER0-DE9REE; Initial Catalog = Chibizov_UP_2; Integrated Security = True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        { 
            if (sqlConnection.State == System.Data.ConnectionState.Open) 
            {
            sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        { 
            return sqlConnection; 
        }
    }
}
