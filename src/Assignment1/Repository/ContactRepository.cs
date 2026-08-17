using Assignment1.Models;

namespace Assignment1.Repository;

/// <summary>
/// Provides a centralized data repository for storing, retrieving contact info entities
/// </summary>
internal class ContactRepository
{
    private readonly List<Contact> _contacts = new List<Contact>();

    /// <summary>
    /// Adds the contact in the repository.
    /// </summary>
    /// <param name="contact">A contact instance to add.</param>
    internal void AddContact(Contact contact)
    {
        this._contacts.Add(contact);
    }

    /// <summary>
    /// Deletes the contact in the repository list
    /// </summary>
    /// <param name="id">Id that should be deleted</param>
    /// <returns>Returns status of the operation with boolean</returns>
    internal bool DeleteContactById(Guid id)
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
    internal IReadOnlyList<Contact> GetAll()
    {
        return this._contacts.ToList();
    }

    /// <summary>
    /// Get Contact By Id
    /// </summary>
    /// <param name="id">Id of the Contact</param>
    /// <returns>A contact with id</returns>
    internal Contact? GetContactById(Guid id)
    {
        return this._contacts.FirstOrDefault(contact => contact.Id == id);
    }
}