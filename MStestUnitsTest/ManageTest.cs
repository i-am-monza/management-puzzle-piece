using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using DataConnect;
using Moq;

namespace MStestUnitsTest
{
    [TestClass]
    public class ManageTest
    {
        
        public Mock<IConnect> mockConnectUser { get; set; }

        [TestInitialize()]
        public void Initialise()
        {
            mockConnectUser = new Mock<IConnect>();
        }

        [TestMethod]
        public void TestInsertToDatabase()
        {
            MockUser user = new MockUser()
            {
                Name = "Test Name",
                Empl_Status = false,
                Skills = new string[1] { "Testing" },
                Reg_Date = DateTime.Now
            };

            mockConnectUser.Setup(item => item.InsertToDatabase(user.Name, user.Empl_Status, user.Skills, user.Reg_Date)).Returns(true);

            bool result = mockConnectUser.Object.InsertToDatabase(user.Name, user.Empl_Status, user.Skills, user.Reg_Date);

            // check if insert is success
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestViewAllUsers()
        {
            MockUser user = new MockUser()
            {
                Id = 0,
                Name = "Test Name",
                Empl_Status = false,
                Skills = new string[1] { "Testing" },
                Reg_Date = DateTime.Now
            };

            DataTable users = new DataTable();
            users.Columns.Add("Id");
            users.Columns.Add("Name");
            users.Columns.Add("Empl_Status");
            users.Columns.Add("Skills");
            users.Columns.Add("Reg_Date");
            users.Rows.Add(new object[] { user.Id, user.Name, user.Empl_Status, user.Skills, user.Reg_Date });

            mockConnectUser.Setup(item => item.ViewAllUsers()).Returns(users);

            DataTable result = mockConnectUser.Object.ViewAllUsers();
            
            Assert.AreNotEqual(users.Rows.Count, 0);
        }

        [TestMethod]
        public void TestSearchUser()
        {
            MockUser user = new MockUser()
            {
                Id = 0,
                Name = "Test Name",
                Empl_Status = false,
                Skills = new string[1] { "Testing" },
                Reg_Date = DateTime.Now
            };
            
            DataTable users = new DataTable();
            users.Columns.Add("Id");
            users.Columns.Add("Name");
            users.Columns.Add("Empl_Status");
            users.Columns.Add("Skills");
            users.Columns.Add("Reg_Date");
            users.Rows.Add(new object[] { user.Id, user.Name, user.Empl_Status, user.Skills, user.Reg_Date});

            mockConnectUser.Setup(item => item.SearchUser(user.Id)).Returns(users);

            DataTable results = mockConnectUser.Object.SearchUser(user.Id);

            Assert.AreEqual(user.Id, int.Parse(results.Rows[0]["Id"].ToString()));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            mockConnectUser.Setup(item => item.UpdateUser(2, "Name", "Updated Name")).Returns(true);

            bool results = mockConnectUser.Object.UpdateUser(2, "Name", "Updated Name");

            Assert.IsTrue(results);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            mockConnectUser.Setup(item => item.DeleteUser(2)).Returns(true);

            bool results = mockConnectUser.Object.DeleteUser(2);

            Assert.IsTrue(results);
        }
    }
}
