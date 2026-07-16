using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="number">Phone number</param>
        /// <returns>Boolean value </returns>
        public static bool IsValidNumber(string number)
        {
            if (number == null)
            {
                return false;
            }

            number = number.Trim();

            return number.All(char.IsDigit);
        }

        /// <summary>
        /// Validate Email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Boolean </returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}