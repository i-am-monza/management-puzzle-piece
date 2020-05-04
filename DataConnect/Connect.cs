using System;
using MySql.Data.MySqlClient;

namespace DataConnect
{
    public abstract class Connect
    {
        // create connection object for opening connection
        MySqlConnection connection;

        public void ConnectToDatabase()
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
            } 
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }

        async public void CloseDatabaseConnection()
        {
            // just in case things break
            try
            {
                //  conclosenection
                await connection.CloseAsync();

                Console.WriteLine("Connection Closed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
        }

        // method for inserting a new user
        public bool InsertToDatabase(string userName, bool emplSTatus, string[] skills, DateTime regDate, string table = "users")
        {
            /*
             * code here
             */

            return true;
        }

        // a method for viewing all users
        public string[] ViewAllUsers(string table = "users")
        {
            /*
             * code here
             */

            return new string[0];
        }

        // a method for searching with user id
        public string[] SearchUser(string id, string table = "users")
        {
            /*
             * code here
             */

            return new string[0];
        }

        // a method for updating user details
        public bool UpdateUser(string id, string fieldForUpdate, string table = "users")
        {
            /*
             * code here
             */

            return false;
        }

        // a method for deleting a user from records
        public bool DeleteUser(string id, string table = "users")
        {
            /*
             * code here
             */

            return false;
        }
    }
}
