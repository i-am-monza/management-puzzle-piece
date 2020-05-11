using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DataConnect
{
    public interface IConnect
    {
        void ConnectToDatabase(MySqlConnection connection);

        void CloseDatabase(MySqlConnection connection);

        bool InsertToDatabase(string userName, bool emplSTatus, string[] skills, DateTime regDate);

        DataTable ViewAllUsers();

        DataTable SearchUser(int id);

        bool UpdateUser(int id, string fieldForUpdate, string value);

        bool DeleteUser(int id);
    }
}
