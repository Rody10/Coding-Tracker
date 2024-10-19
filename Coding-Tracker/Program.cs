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

            Console.WriteLine("Welcome to the Coding Tracker!");
            while (!terminateApp)
            {
                Console.WriteLine("-------------------");
                await CreateDatabase.InitialiseDatabase(args);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("");
                Console.WriteLine("Type 1 to Insert Record.");
                Console.WriteLine("Type 2 to View All Records.");
                Console.WriteLine("Type 3 to Delete Record.");
                Console.WriteLine("Type 4 to Update Record.");
                Console.WriteLine("Type 9 to Close Application.");

                int choice = UserInput.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Insert Record");
                        string startTime = UserInput.GetStartTime();
                        string endTime = UserInput.GetEndTime();
                        CodingSession codingSession = new CodingSession(startTime, endTime);
                        DataController.addCodingSession(codingSession);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }

            }

        }
    }
}