using Assignment1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Ui
{
    /// <summary>
    /// Display
    /// </summary>
    internal class DisplayClass
    {
        /// <summary>
        /// Print all the contact list
        /// </summary>
        /// <param name="contacts">Contacts list</param>
        public void PrintContact(List<ContactInfo> contacts)
        {
            //int i = 1;
            //foreach (ContactInfo contactItem in contact)
            //{
            //    Console.WriteLine($"{i++}. {contactItem.Name}, {contactItem.Email}, {contactItem.Phone}, {contactItem.Notes}");
            //}

            if (contacts.Count > 0)
            {
                var i = 1;
                foreach (ContactInfo contact in contacts)
                {
                    Console.WriteLine($"{i++}. {contact.Name} , {contact.Phone} , {contact.Email} , {contact.Notes} ");
                }
            }
            else
            {
                Console.WriteLine("The Contacts are Empty");
            }
        }
    }
}