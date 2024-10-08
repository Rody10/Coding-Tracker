using System;
using System.Configuration;
using System.Collections.Specialized;
using Coding_Tracker;


namespace CodingTracker
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            bool terminateApp = false;
            UserInput userInput = new UserInput();


            while(!terminateApp)
            {
                Console.WriteLine("Welcome to the Coding Tracker!");
                Console.WriteLine("-------------------");
                await CreateDatabase.InitialiseDatabase(args);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\v");
                Console.WriteLine("Type 1 to Insert Record.");
                Console.WriteLine("Type 2 to View All Records.");
                Console.WriteLine("Type 3 to Delete Record.");
                Console.WriteLine("Type 4 to Update Record.");
                Console.WriteLine("Type 9 to Close Application.");

                int choice = userInput.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Insert Record");
                        // TODO Add logic
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }

            }

        }
    }
}