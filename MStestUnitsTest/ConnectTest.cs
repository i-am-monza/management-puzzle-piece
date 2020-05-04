using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataConnect;

namespace MStestUnitsTest
{
    [TestClass]
    /*Test cases for the Connect class under DataConnect project 
     */
    public class ConnectTest : Connect
    {
        [TestMethod]
        public void TestConnectToDatabase()
        {
            // connect to the database server
            ConnectToDatabase();

            // ping database server by accessing connection object
            bool result = GiveAcces().Ping();

            // ping the connected database
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCloseDatabaseConnection()
        {
            // ping database server by accessing connection object
            bool result = GiveAcces().Ping();

            // ping the connected database
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestInsertToDatabase()
        {
            // setup user variables
            string userName = "Test Name";
            bool emplStatus = false;
            string[] skills = { "Testing" };
            DateTime regDate = new DateTime().Date;
            string table = "users";

            // initiate insert action with details
            bool result = InsertToDatabase(userName, emplStatus, skills, regDate, table);

            // check if insert is success
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestViewAllUsers()
        {
            // declare a empty users array
            string[] users;

            // get all users
            users = ViewAllUsers();

            // test if users are returned
            Assert.AreEqual(users.Length, 1);
        }

        [TestMethod]
        public void TestSearchUser()
        {
            // id to test
            string id = "id";

            // get users details
            string[] user = SearchUser(id);

            // check the user
            Assert.AreEqual(user[0], id);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            // prepare required variables
            string id = "id";
            string fieldToUpdate = "Name";
            string update = "Test Name Update";

            // initiate update action
            bool result = UpdateUser(id, fieldToUpdate, update);

            // check result
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            // user id for deleting
            string id = "id";

            // initiate action
            bool result = DeleteUser(id);

            // check result
            Assert.IsTrue(result);
        }
    }
}
