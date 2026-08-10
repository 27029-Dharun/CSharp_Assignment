namespace Assignment1.Model;

/// <summary>
/// Model class
/// </summary>
internal class Contact
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Contact"/> class.
    /// </summary>
    /// <param name="id">Unique Id assigned during creation</param>
    /// <param name="name">Name of the contact</param>
    /// <param name="email">Email of the contact</param>
    /// <param name="phoneNumber">Phone Number of the contact</param>
    /// <param name="notes">Notes</param>
    internal Contact(Guid id, string name, string phoneNumber, string email, string notes)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Notes = notes;
    }

    /// <summary>
    /// Gets the unique Id of the Contact assigned at creation time.
    /// </summary>
    /// <value>The unique Id of the Contact.</value>
    internal Guid Id { get; }

    /// <summary>
    /// Gets or sets the Name of the Contact.
    /// </summary>
    /// <value>The name of the Contact.</value>
    internal string? Name { get; set; }

    /// <summary>
    /// Gets or sets the Email of the Contact.
    /// </summary>
    /// <value>The Email address of the Contact.</value>
    internal string? Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the Contact.
    /// </summary>
    /// <value>The phone number of the Contact.</value>
    internal string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the Description of the Contact.
    /// </summary>
    /// <value>The Description of the Contact.</value>
    internal string? Notes { get; set; }
}