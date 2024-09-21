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
        string startTime;
        string endTime;
        string duration;

        // constructor
        public CodingSession(string startTime, string endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            duration = calculateDuration(DateTime.Parse(startTime), DateTime.Parse(endTime));  
        }

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
