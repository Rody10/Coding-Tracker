using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    public class CodingSession
    {
        public string startTime { get; private set; }
        public string endTime { get; private set; }
        public string duration { get; private set; }

        
        public CodingSession(string startTime, string endTime)
        {
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
    }
}
