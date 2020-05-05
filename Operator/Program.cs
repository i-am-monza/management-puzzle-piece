using Managers;
using System;
using System.Data;

namespace Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Below are the availbale tables in database [users]:");
            Console.WriteLine("1. regigered.");
            Console.Write("So, which table do you wanna mess with? ");
            // get users choice
            int choice = Console.Read();

            switch(choice)
            {
                case 1:
                    {
                        // connect to class for interacting with registered table
                        Manage managerForRegistered = new Manage();
                        // declare command var
                        char command = 'F';

                        Console.WriteLine("Menu:");
                        do
                        {
                            Console.WriteLine("\tA. Register new user.");
                            Console.WriteLine("\tB. View all Users.");
                            Console.WriteLine("\tC. Search for user with id.");
                            Console.WriteLine("\tD. Update user by id.");
                            Console.WriteLine("\tE. Delete user with id.");
                            Console.WriteLine("\tF. Exit application");

                            switch (command = Console.ReadLine().ToUpper()[0])
                            {
                                case 'A':
                                    {
                                        Console.WriteLine("These are the required fields to enter a new user:\n\tFull Name, Employement Status and Skills.\n");
                                        Console.Write("Please enter full name: ");
                                        string name = Console.ReadLine();
                                        Console.Write("");
                                        Console.Write("Are you legally employed? [Y/N]: ");
                                        char emplRes = Console.ReadLine().ToUpper().ToCharArray()[0];
                                        Console.Write("");
                                        Console.Write("Please enter list of skills, separated by comma (,): ");
                                        string[] skills = Console.ReadLine().Split(',');

                                        // update employement status
                                        bool emplStatus = false;
                                        if (emplRes == 'Y')
                                        {
                                            emplStatus = true;
                                        }

                                        bool cmdStatus = managerForRegistered.InsertToDatabase(name, emplStatus, skills, new DateTime().Date);

                                        if (cmdStatus)
                                        {
                                            Console.WriteLine("User {0} inserted successfully.", name);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error inserting user.");
                                        }
                                        break;
                                    }

                                case 'B':
                                    {
                                        // get all registered users
                                        DataTable users = managerForRegistered.ViewAllUsers();

                                        Console.WriteLine("These are {0} number of users in table.", users.Rows.Count);
                                        // display each record available
                                        foreach(DataRow row in users.Rows)
                                        {
                                            if (!row.IsNull(0))
                                            {
                                                Console.WriteLine("User {0} registered on {1} and has a set employement of status: {2}", row["name"], row["Reg_Date"], row["Empl_Status"]);
                                                Console.WriteLine("Skills: {}", row["Skills"]);
                                            }
                                        }
                                       
                                        break;
                                    }

                                case 'C':
                                    {
                                        Console.Write("Please enter the user id you'd like to search: ");
                                        int searchId = Console.Read();
                                        Console.Write("");

                                        DataTable userRecord = managerForRegistered.SearchUser(searchId);

                                        if(userRecord.Rows.Count > 0)
                                        {
                                            Console.WriteLine("ID: {0}\tName: {1}\tEmployee STatus: {2}\tSkills: {3}\tRegistered: {4}", userRecord.Rows[0], userRecord.Rows[1], userRecord.Rows[2], userRecord.Rows[3], userRecord.Rows[4]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("User with id: {} was not found in registered records.", searchId);
                                        }
                                        break;
                                    }

                                case 'D':
                                    {
                                        Console.Write("Please specify user Id for updating: ");
                                        int id = Console.Read();
                                        Console.Write("");
                                        Console.Write("Please enter the field/property you'd like to update: ");
                                        string field = Console.ReadLine();
                                        Console.Write("");
                                        Console.Write("\tEnter new value for {0}: ", field);
                                        string value = Console.ReadLine();

                                        bool cmdStatus = managerForRegistered.UpdateUser(id, field, value);

                                        if (cmdStatus)
                                        {
                                            Console.WriteLine("Update successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error updating user.");
                                        }
                                        break;
                                    }

                                case 'E':
                                    {
                                        Console.Write("Enter the Id you'd like to delete: ");
                                        int id = Console.Read();
                                        Console.Write("");

                                        // initiate delete
                                        bool cmdStatus = managerForRegistered.DeleteUser(id);

                                        if (cmdStatus)
                                        {
                                            Console.WriteLine("User deleted successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error deleting user.");
                                        }
                                        break;
                                    }
                            }
                        } while (command != 'F');

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
