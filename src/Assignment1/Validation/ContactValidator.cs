using System.Text.RegularExpressions;

namespace Assignment1.Validation
{
    /// <summary>
    /// Contains contact validation methods
    /// </summary>
    internal class ContactValidator
    {
        /// <summary>
        /// Validates all the contact field
        /// </summary>
        /// <param name="name">Name of the contact</param>
        /// <param name="phone">PhoneNumber number</param>
        /// <param name="email">Email</param>
        /// <param name="notes">Notes</param>
        /// <returns>returns string output</returns>
        public static string IsValidContactFields(string name, string phone, string email, string notes)
        {
            if (name.Length <= 3)
            {
                return "Name should be greater than 3 characters";
            }

            if (!IsValidNumber(phone))
            {
                return "Invalid Phone Number";
            }

            if (!IsValidEmail(email))
            {
                return "Invalid Email";
            }

            if (notes.Length > 250)
            {
                return "Can't be greater than 250 characters";
            }

            return string.Empty;
        }

        /// <summary>
        /// Validate phone number
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

            return number.All(char.IsDigit) && number.Length == 10;
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
