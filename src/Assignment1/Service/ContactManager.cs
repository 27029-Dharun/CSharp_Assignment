using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Model;
using Assignment1.Persistance;

namespace Assignment1.Services
{
    /// <summary>
    /// Service class is for manipulating on list.
    /// </summary>
    public class ContactManager
    {
        private Repository _repository = new Repository();

        /// <summary>
        /// Create a contact
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="phone">phone number</param>
        /// <param name="email">Email</param>
        /// <param name="notes">Notes</param>
        /// <returns>A new contact</returns>
        public string CreateContact(string name, string phone, string email, string notes)
        {
            if (name == null)
            {
                return "Name can't be NULL";
            }

            if (Helper.IsValidateNumber(phone))
            {
                return "Invalid Phone";
            }
            Guid id = Guid.NewGuid();
            ContactInfo contact = new ContactInfo {Id = id, Name = name, Phone = phone, Email = email, Notes = notes };
            this._repository.AddContact(contact);
            return "Contact Added Successfully";
        }

        /// <summary>
        /// Search the contact by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>A List/returns>
        public List<ContactInfo> SearchContact(string name)
        {
            List<ContactInfo> contact = _repository.GetContact();
            List<ContactInfo> filtered = new();
            foreach (ContactInfo contactItems in contact)
            {
                if (contactItems.Name.Contains(name))
                {
                    filtered.Add(contactItems);
                }
            }

            return filtered;
        }

        /// <summary>
        /// Display the contacts
        /// </summary>
        /// <returns>A list of contact</returns>
        public List<ContactInfo> DisplayContact()
        {
            return _repository.GetContact();
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id">Index</param>
        public void DeleteContact(Guid id)
        {
            _repository.DeleteContactById(id);
        }

        /// <summary>
        /// Index Validation
        /// </summary>
        /// <param name="index">Index of contact</param>
        /// <returns>Return boolean</returns>
        public bool ValidateIndex(int index)
        {
            List<ContactInfo> contacts = this._repository.GetContact();
            if (index >= 0 && contacts.Count > index)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="id">Index</param>
        /// <param name="option">Field to be edited</param>
        /// <param name="newValue">Edited string</param>
        /// <returns>A boolean flag to represent the status</returns>
        public bool EditContact(Guid id, int option, string newValue)
        {
            if (id == null || option == null || newValue == null)
            {
                return false;
            }

            _repository.EditContact(id, option, newValue);

            return true;
        }

        /// <summary>
        /// Sort by Name all the contacts
        /// </summary>
        public void SortContactByName()
        {
            _repository.SortContactByName();
        }
    }
}