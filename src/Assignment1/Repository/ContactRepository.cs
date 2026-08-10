using Assignment1.Model;

namespace Assignment1.Repository
{
    /// <summary>
    /// Provides a centralized data repository for storing, retrieving contact info entities
    /// </summary>
    public class ContactRepository
    {
        private readonly List<Contact> _contacts = new List<Contact>();

        /// <summary>
        /// Adds a contact in the _contacts list.
        /// </summary>
        /// <param name="contact">A contact instance to add.</param>
        public void AddContact(Contact contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// Deletes the contact in the _contacts list
        /// </summary>
        /// <param name="id">Id that should be deleted</param>
        /// <returns>Returns status of the operation with boolean</returns>
        public bool DeleteContactById(Guid id)
        {
            Contact? contact = this.GetContactById(id);
            if (contact != null)
            {
                this._contacts.Remove(contact);
                return true;
            }

            return false;
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