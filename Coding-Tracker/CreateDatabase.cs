using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Coding_Tracker
{
    public static class CreateDatabase
    {
        public static async Task InitialiseDatabase(string[] args)
        {
            string? DefaultConnectionString = ConfigurationManager.AppSettings.Get("DefaultConnectionString");
            string tableName = "CodeSession";

            if (!File.Exists(DefaultConnectionString))
            {
                Console.WriteLine("Database does not exist!");
                Console.WriteLine("");
                Directory.CreateDirectory("Database");
                SQLiteConnection.CreateFile(DefaultConnectionString);
                Console.WriteLine("Finished creating database");
                Console.WriteLine("");
                Console.WriteLine("Creating table.");

                await using var conn = new SQLiteConnection($"Data Source={DefaultConnectionString}");

                conn.Open();

                await using var cmd = new SQLiteCommand($"CREATE TABLE {tableName} (StartTime TEXT, EndTime TEXT, Duration TEXT)", conn);
                conn.Close();
            }
            else
            {
                Console.WriteLine("Database exists.");
                // await using var conn = new SQLiteConnection($"Data Source={DefaultConncetionString}");
                // Console.WriteLine("");
            }
            
        }
    }
}
