using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tracker
{
    // Remember to implement validation
    public class UserInput
    {
        public int GetMenuChoice()
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

    }
}
