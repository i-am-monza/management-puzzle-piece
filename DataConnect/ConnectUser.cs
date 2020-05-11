using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataConnect
{
    public class ConnectUser : IConnect
    {
        MySqlConnection connection;
       
        public void CloseDatabase(MySqlConnection connection_)
        {
            connection = connection_;

            try
            {
                connection.Close();

            } catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }

        public void ConnectToDatabase(MySqlConnection connection_)
        {
            connection = connection_;

            try
            {
                connection.Open();

            } catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
            
        }

        public bool DeleteUser(int id)
        {
            try
            {
                string query = "DELETE FROM registered WHERE Id=?id;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }

        public bool InsertToDatabase(string userName, bool emplSTatus, string[] skills, DateTime regDate)
        {
            try
            {
                string query = "INSERT INTO registered(Name, Empl_Status, Skills, Reg_Date) VALUES (?Name, ?Empl_Status, ?Skills, ?Reg_Date);";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("?Name", MySqlDbType.VarChar).Value = userName;
                    cmd.Parameters.Add("?Empl_Status", MySqlDbType.VarChar).Value = emplSTatus;
                    cmd.Parameters.Add("?Skills", MySqlDbType.VarChar).Value = string.Join(",", skills);
                    cmd.Parameters.Add("?Reg_Date", MySqlDbType.DateTime).Value = regDate;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }

        public DataTable SearchUser(int id)
        {
            try
            {
                string query = "SELECT * FROM registered WHERE Id=?id;";

                DataTable result = new DataTable();

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id;

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    dataAdapter.Fill(result);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }

        public bool UpdateUser(int id, string fieldForUpdate, string value)
        {
            try
            {
                string query = "UPDATE registered SET " + fieldForUpdate + "='" + value + "' WHERE Id=?id;";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }

        public DataTable ViewAllUsers()
        {
            try
            {
                string query = "SELECT * FROM registered;";

                DataTable results = new DataTable();

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(new MySqlCommand(query, connection)))
                {
                    dataAdapter.Fill(results);
                }

                return results;

            }
            catch (Exception e)
            {
                throw new Exception("Error: {0}", e);
            }
        }
    }
}
