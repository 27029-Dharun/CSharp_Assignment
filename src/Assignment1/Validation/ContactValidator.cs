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
        /// <param name="phone">Phone number</param>
        /// <param name="email">Email</param>
        /// <param name="notes">Notes</param>
        /// <returns>returns string output</returns>
        public static string ValidateContactFields(string name, string phone, string email, string notes)
        {
            if (name == string.Empty)
            {
                return "Name can't be Empty";
            }

            if (phone == null || !Helper.IsValidNumber(phone))
            {
                return "Invalid Phone";
            }

            if (email == null || !Helper.IsValidEmail(email))
            {
                return "Invalid Email";
            }

            if (notes == null)
            {
                return "Not specified";
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
    }
}
