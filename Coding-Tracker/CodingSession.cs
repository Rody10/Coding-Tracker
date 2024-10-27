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
        public string startTime { get; private set; }
        public string endTime { get; private set; }
        public string duration { get; private set; }
        public int codingSessionID { get; private set; }

        
        public CodingSession(string startTime, string endTime)
        {
            codingSessionID = createCodingSessionID();
            Console.WriteLine(codingSessionID);
            this.startTime = startTime;
            this.endTime = endTime;
            duration = calculateDuration(DateTime.Parse(startTime), DateTime.Parse(endTime));
        } // constructor

        // Parameterless constructor (required by Dapper)
        public CodingSession()
        {
        }// constructor

        private string calculateDuration(DateTime startTime, DateTime endTime)
        {
            TimeSpan difference = endTime.Subtract(startTime);
            if (difference.TotalSeconds < 0)
            {
                throw new Exception("Duration cannot be negative");
            }
            return difference.ToString();
        }

        // This method is used by the Update method
        public void updateCodingSessionDuration()
        {
            DateTime startTimeAsDateTime = DateTime.ParseExact(startTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime endTimeAsDateTime = DateTime.ParseExact(endTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            calculateDuration(startTimeAsDateTime, endTimeAsDateTime);
        }

        private int createCodingSessionID()
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
