using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    // Remember to implement validation
    public static class UserInput
    {
        public static int GetMenuChoice()
        {
            Console.Write("Enter your coice (1-4 or 9): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                return choice;
            }
            else
            {
                return 0;
            }
        }
        public static string GetStartTime()
        {
            Console.Write("Please enter the start date and time (dd/MM/yyyy HH:mm): ");
            return Validation.ValidateDateTime();

        }

        public static string GetEndTime()
        {
            Console.Write("Please enter the end date and time (dd/MM/yyyy HH:mm): ");
            return Validation.ValidateDateTime();
        }

        public static int GetCodingSessionID(string operation, List<int> validCodingSessionIDs)
        {
            Console.Write($"Please enter the ID of the CodingSession to {operation}: ");
            return Validation.ValidateCodingSessionID(validCodingSessionIDs);
        }
    }
}
