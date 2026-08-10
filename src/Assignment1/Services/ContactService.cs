using Assignment1.Model;
using Assignment1.Repository;
using Assignment1.Validation;

namespace Assignment1.Services
{
    /// <summary>
    /// Provides service such as add, view, edit and delete contact
    /// </summary>
    public class ContactService
    {
        private ContactRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="repository">Instance of repository</param>
        public ContactService(ContactRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates a new contacts instance and pass it to the repository.
        /// </summary>
        /// <param name="name">Name of the contacts</param>
        /// <param name="phoneNumber">PhoneNumber number of the contacts</param>
        /// <param name="email">Email of the contacts</param>
        /// <param name="notes">Optional Notes</param>
        /// <returns>string message created or not</returns>
        public string CreateContact(string name, string phoneNumber, string email, string notes)
        {
            IReadOnlyList<string> contactNames = this.GetAllName();
            IReadOnlyList<string> contactNumbers = this.GetAllNumber();

            if (ContactServiceValidator.IsUniqueContactNumber(phoneNumber, contactNumbers) && ContactServiceValidator.IsUniqueContactName(name, contactNames))
            {
                Guid id = Guid.NewGuid();
                Contact contact = new Contact(id, name, phoneNumber, email, notes);
                this._repository.AddContact(contact);
                return "Contact Added Successfully";
            }

            return "Name and phone number should be unique";
        }

        /// <summary>
        /// Gets the contacts that contains the name
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
        /// Delete contact by Id.
        /// </summary>
        /// <param name="id">Index</param>
        /// <returns>Boolean status of the operation</returns>
        public bool DeleteContact(Guid id)
        {
            return this._repository.DeleteContactById(id);
        }

        /// <summary>
        /// Updates the contact by getting the field that is to be edited
        /// </summary>
        /// <param name="id">Id of the contact</param>
        /// <param name="name">Name of the contact</param>
        /// <param name="phoneNumber">Phone number of the contact</param>
        /// <param name="email">Email of the contact</param>
        /// <param name="notes">Notes of the contact</param>
        /// <returns>This return a string value</returns>
        public string EditContact(Guid id, string name, string phoneNumber, string email, string notes)
        {
            Contact? contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return "Contact Id Not found\n";
            }

            string? existingPhone = contact.PhoneNumber;
            string? existingName = contact.Name;

            IReadOnlyList<string> contactNames = this.GetAllName();
            IReadOnlyList<string> contactNumbers = this.GetAllNumber();

            // Ignores existing name and phone number while checking unique name and number
            if (ContactServiceValidator.IsUniqueContactNumber(phoneNumber, contactNumbers, existingPhone) && ContactServiceValidator.IsUniqueContactName(name, contactNames, existingName))
            {
                if (name != string.Empty)
                {
                    contact.Name = name;
                }

                if (phoneNumber != string.Empty)
                {
                    if (!ContactInputValidator.IsValidPhoneNumber(phoneNumber))
                    {
                        return "Phone Number Invalid";
                    }

                    contact.PhoneNumber = phoneNumber;
                }

                if (email != string.Empty)
                {
                    if (!ContactInputValidator.IsValidEmail(email))
                    {
                        return "Invalid Email";
                    }

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
        /// Sorts all the contact by Name
        /// </summary>
        /// <returns>Sorted contacts list</returns>
        public IReadOnlyList<Contact> GetSortedByName()
        {
            return this._repository.GetAll().OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Gets all the numbers that are existing
        /// </summary>
        /// <returns>List of strings </returns>
        internal IReadOnlyList<string> GetAllNumber()
        {
            IReadOnlyList<Contact> contacts = this._repository.GetAll();
            List<string> phoneNumbers = new List<string>();
            foreach (Contact contact in contacts)
            {
                if (contact.PhoneNumber is not null)
                {
                    phoneNumbers.Add(contact.PhoneNumber);
                }
            }

            return phoneNumbers;
        }

        /// <summary>
        /// Gets all the names saved and returns the list of names
        /// </summary>
        /// <returns>List of strings contains all the names saved</returns>
        internal IReadOnlyList<string> GetAllName()
        {
            IReadOnlyList<Contact> contacts = this._repository.GetAll();
            List<string> names = new List<string>();
            foreach (Contact contact in contacts)
            {
                if (contact.Name is not null)
                {
                    names.Add(contact.Name);
                }
            }

            return names;
        }
    }
}