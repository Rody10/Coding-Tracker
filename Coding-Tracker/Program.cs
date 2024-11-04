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
            Console.WriteLine("Welcome to the Coding Tracker!");
            Console.WriteLine("-------------------");
            await CreateDatabase.InitialiseDatabase(args);
            bool terminateApp = false;           
            while (!terminateApp)
            {                
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("");
                Console.WriteLine("Type 1 to Insert Record.");
                Console.WriteLine("Type 2 to View All Records.");
                Console.WriteLine("Type 3 to Update Record.");
                Console.WriteLine("Type 4 to Delete Record.");
                Console.WriteLine("Type 9 to Close Application.");

                int choice = UserInput.GetMenuChoice();


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Insert Record");
                        string startTime = UserInput.GetStartTime();
                        string endTime = UserInput.GetEndTime();
                        CodingSession codingSession = new CodingSession(startTime, endTime);
                        DataController.AddCodingSession(codingSession);
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

                    case 3:
                        Console.WriteLine("Update Record");
                        Console.WriteLine("");
                        allRecords = DataController.ReadCodingSessions();
                        List<int> validCodingSessionIDs = new List<int>();
                        foreach (var session in allRecords)
                        {
                            Console.WriteLine($"Session ID: {session.codingSessionID}, Start Time: {session.startTime}, End Time: {session.endTime}, Duration: {session.duration}");
                            validCodingSessionIDs.Add(session.codingSessionID);
                        }
                        Console.WriteLine("");
                        int IDOfCodingSessionToUpdate = UserInput.GetCodingSessionID("update", validCodingSessionIDs);
                        string updatedStartTime = UserInput.GetStartTime();
                        string updatedEndTime = UserInput.GetEndTime();
                        string updatedDuration = Helper.CalculateDuration(DateTime.Parse(updatedStartTime), DateTime.Parse(updatedEndTime));
                        DataController.UpdateCodingSession(updatedStartTime, updatedEndTime, updatedDuration, IDOfCodingSessionToUpdate);
                        break;

                    case 4:
                        Console.WriteLine("Delete Record");
                        Console.WriteLine("");
                        allRecords = DataController.ReadCodingSessions();
                        validCodingSessionIDs = new List<int>();
                        foreach (var session in allRecords)
                        {
                            Console.WriteLine($"Session ID: {session.codingSessionID}, Start Time: {session.startTime}, End Time: {session.endTime}, Duration: {session.duration}");
                            validCodingSessionIDs.Add(session.codingSessionID);
                        }
                        Console.WriteLine("");
                        int IDOfCodingSessionToDelete = UserInput.GetCodingSessionID("delete", validCodingSessionIDs);
                        DataController.DeleteCodingSession(IDOfCodingSessionToDelete);
                        break;

                    case 9:
                        terminateApp = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        break;
                }

            }

        }
    }
}