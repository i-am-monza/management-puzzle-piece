using Managers;
using System;

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

                            switch(command = Console.ReadLine().ToUpper()[0])
                            {
                                case 'A':
                                    {

                                        break;
                                    }
                                default:
                                    {
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
