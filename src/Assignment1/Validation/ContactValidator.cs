using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Validation
{
    /// <summary>
    /// Contact Validation
    /// </summary>
    internal class ContactValidator
    {
        /// <summary>
        /// Validate Contact
        /// </summary>
        /// <param name="contact">Contact</param>
        /// <returns>Error Info Value</returns>
        public static string ValidateContactField(Contact contact)
        {
            if (contact == null)
            {
                return "Contact can't be NULL";
            }

            if (contact.Name == string.Empty)
            {
                return "Name can't be Empty";
            }

            if (contact.Phone == null || !Helper.IsValidNumber(contact.Phone))
            {
                return "Invalid Phone";
            }

            if (contact.Email == null || !Helper.IsValidEmail(contact.Email))
            {
                return "Invalid Email";
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
