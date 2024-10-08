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
    internal class DataController
    {
        string? DefaultConnectionString = ConfigurationManager.AppSettings.Get("DefaultConnectionString");
        async void addCodingSession(String startTime, String endTime, String duration)
        {
            // TODO: Implement insertion of records using Dapper
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sql = "INSERT INTO CodeSesion (StartTime, EndTime, Duration) VALUES (@StartTime, @EndTime, @Duration)";
                {
                    CodingSession codingSession = new CodingSession(startTime, endTime);
                    var rowsAffected = await connection.ExecuteAsync(sql, codingSession);
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                }
                var insertedCodingSessions = connection.Query<CodingSession>("SELECT * FROM CodingSession").ToList();
            }
        }
    }
}
