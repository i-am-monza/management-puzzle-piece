using DataConnect;
using System.Runtime.InteropServices;

namespace Managers
{
    public class Manage : Connect
    {
        // method for managing registed table
        public void ManageRegistered()
        {
            // connect to database
            ConnectToDatabase();

            // close connection to database
            CloseDatabaseConnection();
        }
    }
}
 