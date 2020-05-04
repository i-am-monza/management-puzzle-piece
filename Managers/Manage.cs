using DataConnect;
using System.Runtime.InteropServices;

namespace Managers
{
    public class Manage : Connect
    {
        // method for connecting to the database
        public Manage()
        {
            // connect to database
            ConnectToDatabase();

            // close connection to database
            CloseDatabaseConnection();
        }
    }
}
 