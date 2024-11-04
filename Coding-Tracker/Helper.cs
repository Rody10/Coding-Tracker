using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    public static class Helper
    {
        // This method is used by the Update method
        public static string CalculateDuration(DateTime startTime, DateTime endTime)
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
