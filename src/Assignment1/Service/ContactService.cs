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
        /// Create a contact
        /// </summary>
        /// <param name="contact">Contact object</param>
        /// <returns>A new contact</returns>
        public string CreateContact(Contact contact)
        {
            if (this.CheckUniqueContactNumber(contact.Phone))
            {
                Guid id = Guid.NewGuid();
                contact.Id = id;
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
        /// <param name="contact">New contact object to replace</param>
        /// <returns>A boolean flag to represent the status</returns>
        public string EditContact(Contact contact)
        {
            return this._repository.EditContact(contact.Id, contact);
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