namespace Assignment1.Models;

/// <summary>
/// Represents a contact saved in the repository.
/// </summary>
internal class Contact
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Contact"/> class.
    /// </summary>
    /// <param name="name">Name of the contact</param>
    /// <param name="email">Email of the contact</param>
    /// <param name="phoneNumber">Phone Number of the contact</param>
    /// <param name="notes">Notes</param>
    internal Contact(string name, string phoneNumber, string email, string notes)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Notes = notes;
    }

    /// <summary>
    /// Gets the unique Id of the Contact assigned at creation time.
    /// </summary>
    /// <value>A Guid representing contact's unique identifier.</value>
    internal Guid Id { get; }

    /// <summary>
    /// Gets or sets the Name of the Contact.
    /// </summary>
    /// <value>A string representing the contact's name.</value>
    internal string Name { get; set; }

    /// <summary>
    /// Gets or sets the Email of the Contact.
    /// </summary>
    /// <value>A string representing the contact's email.</value>
    internal string Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the Contact.
    /// </summary>
    /// <value>A string representing the contact's phone number.</value>
    internal string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the Description of the Contact.
    /// </summary>
    /// <value>A string representing the contact's description.</value>
    internal string Notes { get; set; }
}