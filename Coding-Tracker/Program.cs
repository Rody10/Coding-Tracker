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

                    case 2:
                        Console.WriteLine("View All Records");
                        Console.WriteLine("");
                        var allRecords = DataController.ReadCodingSessions();
                        foreach (var session in allRecords)
                        {
                            Console.WriteLine($"Session ID: {session.codingSessionID}, Start Time: {session.startTime}, End Time: {session.endTime}, Duration: {session.duration}");
                        }
                        break;

                    case 3: // TODO
                        Console.WriteLine("Update Record");
                        Console.WriteLine("");
                        allRecords = DataController.ReadCodingSessions();
                        List<int> validCodingSessionIDs = new List<int>();
                        foreach (var session in allRecords)
                        {
                            validCodingSessionIDs.Add(session.codingSessionID);
                        }
                        int IDOfCodingSessionToUpdate = UserInput.GetCodingSessionID("update", validCodingSessionIDs);
                        string updatedStartTime = UserInput.GetStartTime();
                        string updatedEndTime = UserInput.GetEndTime();
                        
                        // Remember to update duration
                        break;

                    case 4:
                        Console.WriteLine("Delete Record");
                        Console.WriteLine("");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }

            }

        }
    }
}