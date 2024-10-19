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
    public static class DataController
    {
        static string? DefaultConnectionString = "Data Source=" + ConfigurationManager.AppSettings.Get("DefaultConnectionString");
        public async static void addCodingSession(CodingSession codingSession)
        {
            // TODO: Implement insertion of records using Dapper
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "INSERT INTO CodeSession (StartTime, EndTime, Duration) VALUES (@startTime, @endTime, @duration)";
                {
                    var rowsAffected = await connection.ExecuteAsync(sql, codingSession);
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                }
                var insertedCodingSessions = connection.Query<CodingSession>("SELECT * FROM CodeSession").ToList();
                foreach (var session in insertedCodingSessions)
                {
                    Console.WriteLine($"Start Time: {session.startTime}, End Time: {session.endTime}, Duration: {session.duration}");
                }
            }
        }
    }
}
