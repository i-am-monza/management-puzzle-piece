using DataConnect;
using Managers;
using System;
using System.Data;

namespace Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectUser admin = new ConnectUser();

            // inject admin
            Manage connectingAdmin = new Manage(admin);

            connectingAdmin.Start();
        }
    }
}
