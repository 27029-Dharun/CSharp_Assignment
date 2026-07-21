using Assignment1.Model;
using Assignment1.Persistance;

namespace Assignment1.Services
{
    /// <summary>
    /// Service class is for manipulating on list.
    /// </summary>
    public class ContactManager
    {
        private ContactRepository _repository = new ContactRepository();

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
            if (name == string.Empty)
            {
                return "Name can't be Empty";
            }

            if (!Helper.IsValidNumber(phone))
            {
                return "Invalid Phone";
            }

            if (!Helper.IsValidEmail(email))
            {
                return "Invalid Email";
            }

            if (this.CheckUniqueContactNumber(phone))
            {
                Guid id = Guid.NewGuid();
                Contact contact = new Contact { Id = id, Name = name, Phone = phone, Email = email, Notes = notes };
                this._repository.AddContact(contact);
                return "Contact Added Successfully";
            }
            else
            {
                return "Contact Number already Exists";
            }
        }

        /// <summary>
        /// Search the contact by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>A List/returns>
        public List<Contact> SearchContactByName(string name)
        {
            List<Contact> contact = this._repository.GetContacts();
            List<Contact> filtered = new ();
            foreach (Contact contactItem in contact)
            {
                if (contactItem?.Name == null)
                {
                    continue;
                }

                if (contactItem.Name.Contains(name))
                {
                    filtered.Add(contactItem);
                }
            }

            return filtered;
        }

        /// <summary>
        /// Display the contacts
        /// </summary>
        /// <returns>A list of contact</returns>
        public List<Contact> GetContacts()
        {
            return this._repository.GetContacts();
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="id">Index</param>
        /// <returns>Status of the operation</returns>
        public string DeleteContact(Guid id)
        {
            return this._repository.DeleteContactById(id);
        }

        /// <summary>
        /// Contact Filtered By Id
        /// </summary>
        /// <param name="id">Guid </param>
        /// <returns>A valid contact</returns>
        public Contact? GetContactById(Guid id)
        {
            List<Contact> contacts = this._repository.GetContacts();
            foreach (Contact contactItem in contacts)
            {
                if (contactItem.Id == id)
                {
                    return contactItem;
                }
            }

            return null;
        }

        /// <summary>
        /// Edit contact
        /// </summary>
        /// <param name="id">Index</param>
        /// <param name="option">Field to be edited</param>
        /// <param name="newValue">Edited string</param>
        /// <returns>A boolean flag to represent the status</returns>
        public string EditContact(Guid id, int option, string newValue)
        {
            if (newValue == string.Empty)
            {
                return "String can't be Empty";
            }

            Contact? person = this.GetContactById(id);

            if (person == null)
            {
                return "Invalid Option selected";
            }

            switch (option)
            {
                case 1:
                    if (newValue != string.Empty)
                    {
                        person.Name = newValue;
                    }
                    else
                    {
                        return "Name can't be Empty";
                    }

                    break;

                case 2:
                    if (Helper.IsValidEmail(newValue))
                    {
                        person.Email = newValue;
                    }
                    else
                    {
                        return "Email is Not valid";
                    }

                    break;

                case 3:
                    if (Helper.IsValidNumber(newValue))
                    {
                        person.Phone = newValue;
                    }
                    else
                    {
                        return "Invalid Mobile Number";
                    }

                    break;

                case 4:
                    person.Notes = newValue;
                    break;

                default:
                    return "Invalid Option ";
            }

            return this._repository.EditContact(id, person);
        }

        /// <summary>
        /// Sort by Name all the contacts
        /// </summary>
        public void SortContactByName()
        {
            this._repository.SortContactByName();
        }

        /// <summary>
        /// Check unique number
        /// </summary>
        /// <returns>boolean value</returns>
        private bool CheckUniqueContactNumber(string number)
        {
            List<Contact> contacts = this._repository.GetContacts();
            foreach (Contact contact in contacts)
            {
                if (contact.Phone == number)
                {
                    return false;
                }
            }

            return true;
        }
    }
}