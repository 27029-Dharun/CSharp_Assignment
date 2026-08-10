namespace Assignment1.Models;

/// <summary>
///  Specifies all the contact manager options.
/// </summary>
internal enum ContactManagerMenuOption
{
    /// <summary>
    /// Represents the option to add new contact.
    /// </summary>
    Create = 1,

    /// <summary>
    /// Represents the option to view all the contacts.
    /// </summary>
    View = 2,

    /// <summary>
    /// Represents the option to edit the existing contact.
    /// </summary>
    Edit = 3,

    /// <summary>
    /// Represents the option to delete the contact.
    /// </summary>
    Delete = 4,

    /// <summary>
    /// Represents the option to find contact by name.
    /// </summary>
    Search = 5,

    /// <summary>
    /// Represents the option to order the contact by name.
    /// </summary>
    Sort = 6,

    /// <summary>
    /// Represents the option to exit from the application.
    /// </summary>
    Exit = 7,
}
