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
    internal class ContactValidation
    {
        /// <summary>
        /// Validate Contact
        /// </summary>
        /// <param name="contact">Contact</param>
        /// <returns>Error Info Value</returns>
        public static string ValidateContactField(Contact contact)
        {
            if (contact.Name == string.Empty)
            {
                return "Name can't be Empty";
            }

            if (!Helper.IsValidNumber(contact.Phone))
            {
                return "Invalid Phone";
            }

            if (!Helper.IsValidEmail(contact.Email))
            {
                return "Invalid Email";
            }

            return string.Empty;
        }
    }
}
