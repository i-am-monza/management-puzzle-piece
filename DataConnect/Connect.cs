using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataConnect
{
    public abstract class Connect 
    {
        // create connection object for opening connection
        MySqlConnection connection;

        public MySqlConnection ConnectToDatabase()
        {
            // assign a connection string to database
            string connectionString = "server=localhost;user id=root;database=users";
            // initialise connection object
            connection = new MySqlConnection(connectionString);
            // just in case things break
            try
            {
                // open connection
                connection.Open();

                Console.WriteLine("Connection Open!");

                return connection;
            } 
            catch(Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }

        async public void CloseDatabaseConnection()
        {
            // just in case things break
            try
            {
                //  close conection
                await connection.CloseAsync();

                Console.WriteLine("Connection Closed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }

        // method for inserting a new user
        public abstract bool InsertToDatabase(string userName, bool emplSTatus, string[] skills, DateTime regDate);

        // a method for viewing all users
        public abstract DataTable ViewAllUsers();

        // a method for searching with user id
        public abstract DataTable SearchUser(int id);

        // a method for updating user details
        public abstract bool UpdateUser(int id, string fieldForUpdate, string value);
        
        // a method for deleting a user from records
        public abstract bool DeleteUser(int id);
    }
}
