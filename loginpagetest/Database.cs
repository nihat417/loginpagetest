using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginpagetest;

public class Database
{
    SqlConnection sqlConnection = new SqlConnection(@"Data Source=SERVIS-MC\SQLEXPRESS;Initial Catalog=LoginRegistrDB;Integrated Security=True");
    public void Openconnection()
    {
        if(sqlConnection.State==System.Data.ConnectionState.Closed)
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

    public SqlConnection Getconnection()
    {
        return sqlConnection;
    }
}
