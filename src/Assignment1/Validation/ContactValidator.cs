using System.Text.RegularExpressions;

namespace Assignment1.Validation
{
    /// <summary>
    /// Contact Validation
    /// </summary>
    internal class ContactValidator
    {
        /// <summary>
        /// This validates all the contact field
        /// </summary>
        /// <param name="name">Name of the contact</param>
        /// <param name="phone">PhoneNumber number</param>
        /// <param name="email">Email</param>
        /// <param name="notes">Notes</param>
        /// <returns>returns string output</returns>
        public static string IsValidContactFields(string name, string phone, string email, string notes)
        {
            if (name == string.Empty)
            {
                return "Name can't be Empty";
            }

            if (phone == null || !IsValidNumber(phone))
            {
                return "Invalid Phone Number";
            }

            if (email == null || !IsValidEmail(email))
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
        /// Index Validation
        /// </summary>
        /// <param name="index">Index of contact</param>
        /// <param name="count">Length of the list</param>
        /// <returns>Return boolean</returns>
        public static bool ValidateIndex(int index, int count)
        {
            return index >= 0 && index < count;
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="number">PhoneNumber number</param>
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
