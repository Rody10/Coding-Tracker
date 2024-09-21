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
            await CreateDatabase.InitialiseDatabase(args);
            // Add your application logic here
        }
    }
}