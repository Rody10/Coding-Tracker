using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    public static class Validation
    {
        public static string validateDateTime()
        {
            while (true)
            {
                // Console.Write("Please enter the start date and time (dd/MM/yyyy HH:mm): "); - caller will handle this
                string? input = Console.ReadLine();
                try
                {
                    DateTime result = DateTime.ParseExact(input, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    string resultDateTime = result.ToString();
                    Console.WriteLine("You entered {0}", resultDateTime);
                    return resultDateTime;
                }
                catch (FormatException)
                {
                    Console.Write("{0} is not in the correct format. Correct format is dd/MM/yyyy HH:mm :", input);
                }
            }
        }
    }
}
