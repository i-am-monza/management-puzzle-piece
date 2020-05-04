using DataConnect;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Managers
{
    public class Manage : Connect
    {
        // declare connection object property
        MySqlConnection connect { get; set; }

        // method for managing registed table
        public Manage()
        {
            // connect to database
            connect = ConnectToDatabase();
        }

        public override bool InsertToDatabase(string userName, bool emplSTatus, string[] skills, DateTime regDate)
        {
            try
            {
                string query = "INSERT INTO registered(Name, Empl_Status, Skills, Reg_Date) VALUES (?Name, ?Empl_Status, ?Skills, ?Reg_Date);";

                using (MySqlCommand cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.Add("?Name", MySqlDbType.VarChar).Value = userName;
                    cmd.Parameters.Add("?Empl_Status", MySqlDbType.VarChar).Value = emplSTatus;
                    cmd.Parameters.Add("?Skills", MySqlDbType.VarChar).Value = skills;
                    cmd.Parameters.Add("?Reg_Date", MySqlDbType.DateTime).Value = regDate;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            } catch (Exception e)
            {
                // close connection if fail
                CloseDatabaseConnection();

                throw new Exception("Error: {0}", e);
            }
        }

        public override DataTable ViewAllUsers()
        {
            try
            {
                string query = "SELECT * FROM registered;";
                // create an object for storing table
                DataTable results = new DataTable();

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(new MySqlCommand(query)))
                {
                    dataAdapter.Fill(results);
                }

                return results;

            }
            catch (Exception e)
            {
                // close connection if fail
                CloseDatabaseConnection();

                throw new Exception("Error: {0}", e);
            }
        }

        public override DataTable SearchUser(string id)
        {
            try
            {
                string query = "SELECT * FROM registered WHERE Id = ?id;";
                // initialise table object for result
                DataTable result = new DataTable();
                // create command
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id;

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    dataAdapter.Fill(result);

                    return result;
                }
            }
            catch (Exception e)
            {
                // close connection if fail
                CloseDatabaseConnection();

                throw new Exception("Error: {0}", e);
            }
        }

        public override bool UpdateUser(string id, string fieldForUpdate, string value)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
 