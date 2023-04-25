using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                QueryFabric(conn);
                QueryProducts(conn);
                QueryOrders(conn);
                // QueryEmployee(conn);
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            Console.Read();
        }

        private static void QueryEmployee(MySqlConnection conn)
        {
            string id, name, country;
            string sql = "SELECT code, name, continent FROM country";
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["code"].ToString();
                        name = reader["name"].ToString();
                        country = reader["continent"].ToString();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Код: " + id + " Название: " + name + " Континент: " + country);
                        Console.WriteLine("-----------------------------------------------");
                    }
                }
            }
        }
        private static void QueryFabric(MySqlConnection conn)
        {
            string id, title, boss_name, phone;
            string sql = "SELECT fabric_id, title, boss_name, phone FROM fabric";
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["fabric_id"].ToString();
                        title= reader["title"].ToString();
                        boss_name = reader["boss_name"].ToString();
                        phone = reader["phone"].ToString();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Код: " + id + " Название: " + title + " Номер: " + phone + " Имя боса: " + boss_name);
                        Console.WriteLine("-----------------------------------------------");
                    }
                }
            }
        }
        private static void QueryProducts(MySqlConnection conn)
        {
            string product_id, price, type, min_amount, expiration_time, title;
            string sql = "SELECT product_id, price, type, min_amount, expiration_time, title FROM products";
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product_id = reader["product_id"].ToString();
                        price = reader["price"].ToString();
                        type = reader["type"].ToString();
                        min_amount = reader["min_amount"].ToString();
                        expiration_time = reader["expiration_time"].ToString();
                        title = reader["title"].ToString();

                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Код: " + product_id + " Название: " + title + " Цена: " + price + " Сорт: " + type + " Мін. кількість: " + min_amount + " Термін придатності: " + expiration_time);
                        Console.WriteLine("-----------------------------------------------");
                    }
                }
            }
        }
        private static void QueryOrders(MySqlConnection conn)
        {
            string order_id, product_name, fabric_id, quality_level, products_quantity, registration_date;
            string sql = "SELECT order_id, product_name, fabric_id, quality_level, products_quantity, registration_date FROM orders";
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        order_id = reader["order_id"].ToString();
                        product_name = reader["product_name"].ToString();
                        fabric_id = reader["fabric_id"].ToString();
                        quality_level = reader["quality_level"].ToString();
                        products_quantity = reader["products_quantity"].ToString();
                        registration_date = reader["registration_date"].ToString();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Код: " + order_id + " Название: " + product_name + " Код фабрики: " + fabric_id + " Якість: " + quality_level + " Кількість: " + products_quantity + " Дата регістрації: " + registration_date);
                        Console.WriteLine("-----------------------------------------------");
                    }
                }
            }
        }

    }
}
