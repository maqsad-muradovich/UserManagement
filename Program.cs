using System;
using UserManagment.Brokers;
using UserManagment.Services;

namespace UserManagment.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService(new StorageBroker());

            while (true)
            {
                Console.WriteLine("1. Add credential");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter username: ");
                        string username = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();

                        try
                        {
                            userService.AddCredential(username, password);
                            Console.WriteLine("Credential added successfully!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter username: ");
                        string loginUsername = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string loginPassword = Console.ReadLine();

                        if (userService.Login(loginUsername, loginPassword))
                        {
                            Console.WriteLine("Login successful!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password!");
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}
