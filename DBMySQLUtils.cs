using System;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    class DBMySQLUtils
    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            return new MySqlConnection(connString);
        }
    }

    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "WIN-OFGSILVP72U";
            int port = 3306;
            // string database = "world";
            string database = "fabric_products";
            string username = "monty";
            string password = "some_pass";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
