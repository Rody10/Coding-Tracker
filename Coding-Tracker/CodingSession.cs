using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{

    public class CodingSession
    {
        static string? DefaultConnectionString = "Data Source=" + ConfigurationManager.AppSettings.Get("DefaultConnectionString");
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public string Duration { get; private set; }
        public int CodingSessionID { get; private set; }

        
        public CodingSession(string startTime, string endTime)
        {
            CodingSessionID = CreateCodingSessionID();
            this.StartTime = startTime;
            this.EndTime = endTime;
            Duration = CalculateDuration(DateTime.Parse(startTime), DateTime.Parse(endTime));
        } // constructor

        // Parameterless constructor (required by Dapper)
        public CodingSession()
        {
        }// constructor

        private string CalculateDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan difference = endTime.Subtract(startTime);
            if (difference.TotalSeconds < 0)
            {
                throw new Exception("Duration cannot be negative");
            }
            return difference.ToString();
        }
        private static int CreateCodingSessionID()
        // ID for each row. If table is empty, ID is 1 otherwise increament
        {
            using (var connection = new SQLiteConnection(DefaultConnectionString))
            {
                var sqlNumberOfRows = "SELECT COUNT(*) FROM CodeSession";
                int numberOfRows = Convert.ToInt32(connection.ExecuteScalar(sqlNumberOfRows));
                if (numberOfRows == 0)
                {
                    return 1;
                }
                else
                {
                    return ++numberOfRows;
                }
            }            
        }
    }
}
