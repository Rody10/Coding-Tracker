using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;

namespace Coding_Tracker
{
    // Find out if you need to close connections
    public static class DataController
    {
        static string? DefaultConnectionString = "Data Source=" + ConfigurationManager.AppSettings.Get("DefaultConnectionString");
        public async static void AddCodingSession(CodingSession codingSession)
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "INSERT INTO CodeSession (CodingSessionID, StartTime, EndTime, Duration) VALUES (@codingSessionID, @startTime, @endTime, @duration)";
                {
                    int numberOfRowsInserted = await connection.ExecuteAsync(sql, codingSession);
                    Console.WriteLine($"{numberOfRowsInserted} row(s) inserted.");
                }
            }
        }

        public static List<CodingSession> ReadCodingSessions()
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var insertedCodingSessions = connection.Query<CodingSession>("SELECT * FROM CodeSession").ToList();
                return insertedCodingSessions;
            }
        }

        public static void UpdateCodingSession(string updatedStartTime, string updatedEndTime, string updatedDuration, int IDOfCodingSessionToUpdate)
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "UPDATE CodeSession SET StartTime = @updatedStartTime, EndTime = @updatedEndTime, Duration = @updatedDuration WHERE CodingSessionID = @IDOfCodingSessionToUpdate";
                {
                    int numberOfRowsUpdated = connection.Execute(sql, new {updatedStartTime, updatedEndTime, updatedDuration, IDOfCodingSessionToUpdate });
                    Console.WriteLine($"{numberOfRowsUpdated} row(s) have been updated");
                }
            }

        }
        public static void DeleteCodingSession(int IDOfCodingSessionToDelete)
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "DELETE FROM CodeSession WHERE CodingSessionID = @IDOfCodingSessionToDelete";
                {
                    int numberOfRowsDeleted = connection.Execute(sql, new {IDOfCodingSessionToDelete});
                    Console.WriteLine($"{numberOfRowsDeleted} row(s) have been deleted");
                }
            }

        }
    }
}
