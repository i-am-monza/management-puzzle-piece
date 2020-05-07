using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnect
{
    public interface IConnect
    {
        void ConnectToDatabase(string connectionString);

        void CloseDatabase();

        bool InsertToDatabase(string userName, bool emplSTatus, string[] skills, DateTime regDate);

        DataTable ViewAllUsers();

        DataTable SearchUser(int id);

        bool UpdateUser(int id, string fieldForUpdate, string value);

        bool DeleteUser(int id);
    }
}
