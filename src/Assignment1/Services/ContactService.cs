using Assignment1.Models;
using Assignment1.Repository;
using Assignment1.Validation;

namespace Assignment1.Services;

/// <summary>
/// Provides service such as add, view, edit and delete contact
/// </summary>
internal class ContactService
{
    private readonly ContactRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactService"/> class.
    /// </summary>
    /// <param name="repository">Instance of repository</param>
    internal ContactService(ContactRepository repository)
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
    internal string CreateContact(string name, string phoneNumber, string email, string notes)
    {
        IReadOnlyList<string> contactNames = this.GetAllName();
        IReadOnlyList<string> contactNumbers = this.GetAllNumber();

        if (notes.Equals(string.Empty))
        {
            notes = "Not specified";
        }

        if (ContactServiceValidator.IsUniqueField(phoneNumber, contactNumbers) && ContactServiceValidator.IsUniqueField(name, contactNames))
        {
            Contact contact = new Contact(name, phoneNumber, email, notes);
            this._repository.AddContact(contact);
            return "Contact added successfully";
        }

        return "Name and phone number should be unique";
    }

    /// <summary>
    /// Gets the contacts that contains the name
    /// </summary>
    /// <param name="name">Optional Name of the person to search</param>
    /// <returns>Contacts containing the name</returns>
    internal IReadOnlyList<Contact> FindByNameContaining(string name)
    {
        IReadOnlyList<Contact> contacts = this._repository.GetAll();
        var filtered = contacts.Where(c => c.Name != null && c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        return filtered;
    }

    /// <summary>
    /// Gets the contacts from repository.
    /// </summary>
    /// <returns>A list of contacts</returns>
    internal IReadOnlyList<Contact> GetContacts()
    {
        return this._repository.GetAll();
    }

    /// <summary>
    /// Delete contact by Id.
    /// </summary>
    /// <param name="id">Index</param>
    /// <returns>Boolean status of the operation</returns>
    internal bool DeleteContact(Guid id)
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
    internal string EditContact(Guid id, string name, string phoneNumber, string email, string notes)
    {
        Contact? contact = this._repository.GetContactById(id);
        if (contact is null)
        {
            return "Contact Id not found\n";
        }

        string existingPhoneNumber = contact.PhoneNumber;
        string existingName = contact.Name;

        IReadOnlyList<string> contactNames = this.GetAllName();
        IReadOnlyList<string> contactNumbers = this.GetAllNumber();

        // Ignores existing name and phone number while checking unique name and number
        if (ContactServiceValidator.IsUniqueField(phoneNumber, contactNumbers, existingPhoneNumber) && ContactServiceValidator.IsUniqueField(name, contactNames, existingName))
        {
            // Assigns the new value if the user input is not empty
            if (!name.Equals(string.Empty))
            {
                contact.Name = name;
            }

            if (!phoneNumber.Equals(string.Empty))
            {
                contact.PhoneNumber = phoneNumber;
            }

            if (!email.Equals(string.Empty))
            {
                contact.Email = email;
            }

            if (!notes.Equals(string.Empty))
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
    internal IReadOnlyList<Contact> GetSortedByName()
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
        return contacts
        .Select(c => c.PhoneNumber)
        .ToList();
    }

    /// <summary>
    /// Gets all the names saved and returns the list of names
    /// </summary>
    /// <returns>List of strings contains all the names saved</returns>
    internal IReadOnlyList<string> GetAllName()
    {
        IReadOnlyList<Contact> contacts = this._repository.GetAll();
        return contacts
        .Select(c => c.Name)
        .ToList();
    }
}