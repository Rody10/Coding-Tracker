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
        public async static void addCodingSession(CodingSession codingSession)
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "INSERT INTO CodeSession (CodingSessionID, StartTime, EndTime, Duration) VALUES (@codingSessionID, @startTime, @endTime, @duration)";
                {
                    var rowsAffected = await connection.ExecuteAsync(sql, codingSession);
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
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

        public static void UpdateCodingSession(string startTime, string endTime)
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "UPDATE Product SET Name = Name + @suffix WHERE CategoryID = @categoryID";
                {
                    connection.Execute(sql, new { categoryID = 1, suffix = " (Updated)" });
                }
            }

        }
    }
}
