using DataConnect;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Managers
{
    public class Manage
    {
        IConnect connectActions;
        
        public Manage(IConnect conectingUser)
        {
            connectActions = conectingUser;
        }

        public void Start ()
        {
            Console.WriteLine("\t******************");
            Console.WriteLine("Below are the availbale tables in database [users]:");
            Console.WriteLine("\t******************");
            Console.WriteLine("\t1. regigered.");
            Console.Write("So, which table do you wanna mess with? ");

            int choice = 0;
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                choice = Int32.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The expected input is a positive integer greater than 0.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Try again? ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                choice = Int32.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        char command = 'F';

                        Console.WriteLine("Menu:");
                        do
                        {
                            Console.WriteLine("\tA. Connect.");
                            Console.WriteLine("\tB. Register new user.");
                            Console.WriteLine("\tC. View all Users.");
                            Console.WriteLine("\tD. Search for user with id.");
                            Console.WriteLine("\tE. Update user by id.");
                            Console.WriteLine("\tF. Delete user with id.");
                            Console.WriteLine("\tG. Disconnect.");
                            Console.WriteLine("\tH. Exit application");

                            Console.ForegroundColor = ConsoleColor.Yellow;

                            switch (command = Console.ReadLine().ToUpper()[0])
                            {
                                case 'A':
                                    {
                                        string connectionString = "server=localhost;user id=root;database=users";

                                        connectActions.ConnectToDatabase(connectionString);

                                        Console.WriteLine("Connected.!");

                                        break;
                                    }

                                case 'B':
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("These are the required fields to enter a new user:\n\tFull Name, Employement Status and Skills.\n");
                                        Console.Write("Please enter full name: ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        string name = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("");
                                        Console.Write("Are you legally employed? [Y/N]: ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;

                                        char emplRes = 'N';
                                        try
                                        {
                                            emplRes = Console.ReadLine().ToUpper().ToCharArray()[0];
                                        }
                                        catch
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Error with entered input type.\nPlease specificly enter 'Y' for yes or 'N' for no. ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("Lets try again: ");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            emplRes = Console.ReadLine().ToUpper().ToCharArray()[0];
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("");
                                        Console.Write("Please enter list of skills, separated by comma (,): ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        string[] skills = Console.ReadLine().Split(',');
                                        Console.ForegroundColor = ConsoleColor.White;

                                        // update employement status
                                        bool emplStatus = false;
                                        if (emplRes == 'Y')
                                        {
                                            emplStatus = true;
                                        }

                                        // insert fucntion
                                        bool cmdStatus = connectActions.InsertToDatabase(name, emplStatus, skills, DateTime.Now);

                                        if (cmdStatus)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("User {0} inserted successfully.", name);
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Error inserting user.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        break;
                                    }

                                case 'C':
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        // get all registered users
                                        DataTable users = connectActions.ViewAllUsers();

                                        Console.WriteLine("There are {0} users in table.\n", users.Rows.Count);
                                        // display each record available
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        foreach (DataRow row in users.Rows)
                                        {
                                            if (!row.IsNull(0))
                                            {
                                                Console.WriteLine("User {0}, with ID: {1}, registered on {2} and has a set employement of status: {3}.",
                                                    row.Field<string>("Name"),
                                                    row.Field<int>("Id").ToString(),
                                                    row.Field<DateTime>("Reg_Date").ToString(),
                                                    row.Field<string>("Empl_Status"));
                                                Console.WriteLine("Skills: {0}", row.Field<string>("Skills"));
                                                Console.WriteLine("");
                                            }
                                        }
                                        Console.ForegroundColor = ConsoleColor.White;

                                        break;
                                    }

                                case 'D':
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("Please enter the user id you'd like to search: ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        int searchId = Int32.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("");

                                        DataTable userRecord = connectActions.SearchUser(searchId);


                                        if (userRecord.Rows.Count > 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\n\tID: {0}\n\tName: {1}\n\tEmployee STatus: {2}\n\tSkills: {3}\n\tRegistered: {4}\n",
                                                userRecord.Rows[0].Field<int>("Id"),
                                                userRecord.Rows[0].Field<string>("Name"),
                                                userRecord.Rows[0].Field<string>("Empl_Status"),
                                                userRecord.Rows[0].Field<string>("Skills"),
                                                userRecord.Rows[0].Field<DateTime>("Reg_Date"));
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("User with id: {0} was not found in registered records.", searchId);
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        break;
                                    }

                                case 'E':
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("Please specify user Id for updating: ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        int id = Int32.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("");
                                        Console.Write("Please enter the field/property you'd like to update: ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        string field = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("");
                                        Console.Write("\tEnter new value for {0}: ", field);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        string value = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.White;

                                        bool cmdStatus = connectActions.UpdateUser(id, field, value);

                                        if (cmdStatus)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Update successfully.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Error updating user.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        break;
                                    }

                                case 'F':
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("Enter the Id you'd like to delete: ");
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        int id = Int32.Parse(Console.ReadLine());
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("");

                                        // initiate delete
                                        bool cmdStatus = connectActions.DeleteUser(id);

                                        if (cmdStatus)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("User deleted successfully.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Error deleting user.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        break;
                                    }

                                case 'G':
                                    {
                                        connectActions.CloseDatabase();
                                        Console.WriteLine("Connection closed!");

                                        break;
                                    }

                                default:
                                    {
                                        if (command != 'F')
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Unrecognised input there, please try again or 'F'");
                                            Console.WriteLine("");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        break;
                                    }
                            }
                        } while (command != 'H');

                        Console.ForegroundColor = ConsoleColor.White;
                        connectActions.CloseDatabase();

                        break;
                    }
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You command was not listed or recognised. Please try again");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
            }
        }
    }
}
 