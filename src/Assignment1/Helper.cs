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
        public static bool IsValidateNumber(string number)
        {
            if (number == null || (number.Length != 0 && number.All(char.IsDigit)))
            {
                return false;
            }

            return true;
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