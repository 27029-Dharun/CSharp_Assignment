using Assignment1.Model;
using Assignment1.Persistance;

namespace Assignment1.Services
{
    /// <summary>
    /// Service class is for manipulating on list.
    /// </summary>
    public class ContactService
    {
        private ContactRepository _repository = new ContactRepository();

        /// <summary>
        /// Creates a new contacts object and pass it to a repository
        /// </summary>
        /// <param name="name">Name of the contacts</param>
        /// <param name="phoneNumber">PhoneNumber number of the contacts</param>
        /// <param name="email">Email of the contacts</param>
        /// <param name="notes">Optinal Notes of the contacts</param>
        /// <returns>string message created or not</returns>
        public Contact? CreateContact(string name, string phoneNumber, string email, string notes)
        {
            if (this.IsUniqueContactNumber(phoneNumber) && this.IsUniqueContactName(name))
            {
                Guid id = Guid.NewGuid();
                Contact contact = new Contact(id, name, phoneNumber, email, notes);
                this._repository.AddContact(contact);
                return contact;
            }

            return null;
        }

        /// <summary>
        /// Finds the contacts that containing the name
        /// </summary>
        /// <param name="name">Optional Name of the person to search</param>
        /// <returns>Contacts containing the name</returns>
        public IReadOnlyList<Contact> FindByNameContaining(string name)
        {
            IReadOnlyList<Contact> contacts = this._repository.GetAll();
            var filtered = contacts.Where(c => c.Name != null && c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

            return filtered;
        }

        /// <summary>
        /// Gets the contacts from repository.
        /// </summary>
        /// <returns>A list of contacts</returns>
        public IReadOnlyList<Contact> GetContacts()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Delete Contact by Id.
        /// </summary>
        /// <param name="id">Index</param>
        /// <returns>Status of the operation</returns>
        public string DeleteContact(Guid id)
        {
            return this._repository.DeleteContactById(id);
        }

        /// <summary>
        /// Gets contacts filtered By Id
        /// </summary>
        /// <param name="id">Guid </param>
        /// <returns>A valid contacts</returns>
        public Contact? GetContactById(Guid id)
        {
            IReadOnlyList<Contact> contacts = this._repository.GetAll();
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
        /// This method updates the field and create a new contacts object with same id
        /// </summary>
        /// <param name="id">Id of the contacts</param>
        /// <param name="name">Name of the contacts</param>
        /// <param name="phoneNumber">PhoneNumber of the contacts</param>
        /// <param name="email">Email of the contacts</param>
        /// <param name="notes">Notes of the contacts</param>
        /// <param name="existingPhone">Existing phone number of the contacts</param>
        /// <param name="existingName">Exisiting Name of the contacts</param>
        /// <returns>This return a string value</returns>
        public string EditContact(Guid id, string name, string phoneNumber, string email, string notes, string? existingPhone = null, string? existingName = null)
        {
            Contact? contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return "Contact Id Not found";
            }

            // Ignores existing name and phone number while checking unique name and number
            if (this.IsUniqueContactNumber(phoneNumber, existingPhone) && this.IsUniqueContactName(name, existingName))
            {
                if (name != string.Empty)
                {
                    contact.Name = name;
                }

                if (phoneNumber != string.Empty)
                {
                    contact.PhoneNumber = phoneNumber;
                }

                if (email != string.Empty)
                {
                    contact.Email = email;
                }

                if (notes != string.Empty)
                {
                    contact.Notes = notes;
                }

                return "Updated Successfully";
            }

            return "Mobile Number or Name already Exist";
        }

        /// <summary>
        /// Sort by Name all the contacts
        /// </summary>
        /// <returns>Sorted contacts list</returns>
        public IReadOnlyList<Contact> GetSortedByName()
        {
            return this._repository.GetAll().OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Checks unique mobile number
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="exisitingPhone">Existing number only when editing</param>
        /// <returns>boolean value</returns>
        private bool IsUniqueContactNumber(string number, string? exisitingPhone = null)
        {
            IReadOnlyList<Contact> contacts = this._repository.GetAll();
            foreach (Contact contact in contacts)
            {
                if (contact.PhoneNumber == number && exisitingPhone != number)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the name is unique
        /// </summary>
        /// <param name="name">Name of the contacts</param>
        /// <returns>Returns boolean</returns>
        private bool IsUniqueContactName(string name, string? existingName = null)
        {
            IReadOnlyList<Contact> contacts = this._repository.GetAll();
            foreach (Contact contact in contacts)
            {
                if (contact.Name == name && existingName != name)
                {
                    return false;
                }
            }

            return true;
        }
    }
}