using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Managers;
using System.Data;

namespace MStestUnitsTest
{
    [TestClass]
    /*Test cases for the Connect class under DataConnect project 
     */
    public class ManageTest
    {
        [TestMethod]
        public void TestInsertToDatabase()
        {
            // Manage instance
            Manage manager = new Manage();
            // setup user variables
            string userName = "Test Name";
            bool emplStatus = false;
            string[] skills = { "Testing" };
            DateTime regDate = new DateTime().Date;

            // initiate insert action with details
            bool result = manager.InsertToDatabase(userName, emplStatus, skills, regDate);

            // check if insert is success
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestViewAllUsers()
        {
            // Manage instance
            Manage manager = new Manage();
        
            // get all users
            DataTable users = manager.ViewAllUsers();

            // test if users are returned
            Assert.AreNotEqual(users.Rows, 0);
        }

        [TestMethod]
        public void TestSearchUser()
        {
            // Manage instance
            Manage manager = new Manage();
            // id to test
            int id = 0;

            // get users details
            DataTable user = manager.SearchUser(id);
            // search for specific id
            foreach(DataRow row in user.Rows)
            {
                if (Int32.Parse(row["Id"].ToString()) == id)
                    // check the user
                    Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            // Manage instance
            Manage manager = new Manage();
            // prepare required variables
            int id = 0;
            string fieldToUpdate = "Name";
            string update = "Test Neame Update";

            // initiate update action
            bool result = manager.UpdateUser(id, fieldToUpdate, update);

            // check result
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDeleteUser()
        {   
            // Manage instance
            Manage manager = new Manage();
            // user id for deleting
            int id = 0;

            // initiate action
            bool result = manager.DeleteUser(id);

            // check result
            Assert.IsTrue(result);
        }
    }
}
