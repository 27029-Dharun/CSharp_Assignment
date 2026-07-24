using Assignment1.Model;
using Assignment1.Persistance;
using Assignment1.Validation;

namespace Assignment1.Services
{
    /// <summary>
    /// Service class is for manipulating on list.
    /// </summary>
    public class ContactService
    {
        private ContactRepository _repository = new ContactRepository();

        /// <summary>
        /// This method creates a new contact object and pass it to a repository
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="phone">Phone number of the peson</param>
        /// <param name="email">Email</param>
        /// <param name="notes">Notes</param>
        /// <returns>string message created or not</returns>
        public Contact? CreateContact(string name, string phone, string email, string notes)
        {
            if (this.CheckUniqueContactNumber(phone))
            {
                Guid id = Guid.NewGuid();
                Contact contact = new Contact()
                {
                    Id = id,
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Notes = notes,
                };
                this._repository.AddContact(contact);
                return contact;
            }

            return null;
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
        /// This method updates the field and create a new contact object with same id
        /// </summary>
        /// <param name="id">Id </param>
        /// <param name="name">Name</param>
        /// <param name="phone">Phone</param>
        /// <param name="email">Email</param>
        /// <param name="notes">Notes</param>
        /// <returns>This return a string value</returns>
        public string EditContact(Guid id, string name, string phone, string email, string notes)
        {
            Contact contact = new Contact
            {
                Id = id,
                Name = name,
                Email = email,
                Phone = phone,
                Notes = notes,
            };

            return this._repository.EditContact(id, contact);
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