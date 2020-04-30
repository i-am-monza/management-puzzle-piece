using System;
using MySql.Data.MySqlClient;

namespace DataConnect
{
    public class Connect
    {
        Connect()
        {
            // assign a connection string to database
            string connectionString = "server=localhost;database=Management;uid=root;";
            // create connection object for opening connection
            MySqlConnection connection = new MySqlConnection(connectionString);

            // just in case things break
            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");
            } 
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }
    }
}
