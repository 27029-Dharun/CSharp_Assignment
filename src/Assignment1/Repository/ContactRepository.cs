using Assignment1.Model;

namespace Assignment1.Persistance
{
    /// <summary>
    /// Contacts stored as list
    /// </summary>
    public class ContactRepository
    {
        private readonly List<Contact> _contacts = new();

        /// <summary>
        /// Creates contact in the _contacts list.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Deletes the contact in the _contacts list
        /// </summary>
        /// <param name="id">Id that should be deleted</param>
        /// <returns>Returns status</returns>
        public string DeleteContactById(Guid id)
        {
            Contact? contact = this.GetContactById(id);
            if (contact != null)
            {
                this._contacts.Remove(contact);
                return "Contact Deleted Successfully";
            }

            return "Failed to Delete Contact";
        }

        /// <summary>
        /// Updates the contact in the _contacts list
        /// </summary>
        /// <param name="contactName"> this is the contactName that should be updated to the list</param>
        /// <returns>The contact list.</returns>
        public IReadOnlyList<Contact> GetAll()
        {
            return this._contacts.ToList();
        }

        /// <summary>
        /// Edit contact by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="contact">New value to be changed</param>
        /// <returns>string to denote error</returns>
        public string EditContact(Guid id, Contact contact)
        {
            Contact? record = this.GetContactById(id);
            if (record != null)
            {
                record.Name = contact.Name;
                record.PhoneNumber = contact.PhoneNumber;
                record.Email = contact.Email;
                record.Notes = contact.Notes;
                return "Contact Updated Successfully";
            }

            return "Contact Not Found";
        }

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="id">Id of the Contact</param>
        /// <returns>A contact with id</returns>
        public Contact? GetContactById(Guid id)
        {
            return this._contacts.FirstOrDefault(contact => contact.Id == id);
        }
    }
}