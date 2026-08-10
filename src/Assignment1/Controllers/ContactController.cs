using Assignment1.Models;
using Assignment1.Services;
using Assignment1.Views;

namespace Assignment1.Controllers;

/// <summary>
/// Controls flow between view and services.
/// </summary>
internal class ContactController
{
    private readonly ContactService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactController"/> class.
    /// </summary>
    /// <param name="view">Views object</param>
    /// <param name="service">Services object</param>
    internal ContactController(ContactService service)
    {
        this._service = service;
    }

    /// <summary>
    /// Loops and gets menu as input.
    /// </summary>
    internal void HandleMenuOption()
    {
        ConsoleView.PrintInfo("Contact Manager Application");
        ContactManagerMenuOption option;
        do
        {
            option = (ContactManagerMenuOption)ConsoleView.GetInteger(
                "Welcome to contact manager console application\n" +
                "1. Create new contact\n" +
                "2. View contact\n" +
                "3. Edit contact\n" +
                "4. Delete contact\n" +
                "5. Search contact by name\n" +
                "6. Sort contact by name\n" +
                "7. Exit\n" +
                " Choose an option: ");

            ConsoleView.Clear();

            switch (option)
            {
                case ContactManagerMenuOption.Create:
                    this.CreateContact();
                    break;

                case ContactManagerMenuOption.View:
                    this.ViewContact();
                    break;

                case ContactManagerMenuOption.Edit:
                    this.EditContact();
                    break;

                case ContactManagerMenuOption.Delete:
                    this.DeleteContact();
                    break;

                case ContactManagerMenuOption.Search:
                    this.SearchContactByName();
                    break;

                case ContactManagerMenuOption.Sort:
                    this.SortContactByName();
                    break;

                case ContactManagerMenuOption.Exit:
                    return;

                default:
                    ConsoleView.PrintInfo("Please enter an input in range 1 - 7");
                    break;
            }
        }
        while (option != ContactManagerMenuOption.Exit);
    }

    /// <summary>
    /// Creates contact and validates the option.
    /// </summary>
    internal void CreateContact()
    {
        string name = ConsoleView.GetContactName("Enter name: ");
        string phoneNumber = ConsoleView.GetPhoneNumber("Enter phone number: ");
        string email = ConsoleView.GetEmail("Enter email address: ");
        string notes = ConsoleView.GetNotes("Enter notes (optional): ");

        ConsoleView.PrintInfo(this._service.CreateContact(name, phoneNumber, email, notes));
        ConsoleView.PrintEmptyLine();
    }

    /// <summary>
    /// Displays the all contacts.
    /// </summary>
    internal void ViewContact()
    {
        IReadOnlyList<Contact> contacts = this._service.GetContacts();
        ConsoleView.PrintContact(contacts);
    }

    /// <summary>
    /// Edits the contact selected.
    /// </summary>
    internal void EditContact()
    {
        var contacts = this._service.GetContacts();
        if (contacts.Count == 0)
        {
            ConsoleView.PrintInfo("Nothing to edit\n");
            return;
        }

        ConsoleView.PrintInfo("Select the contact to edit: ");
        ConsoleView.PrintContact(contacts);
        int index = ConsoleView.GetValidContactIndex(contacts.Count);
        Guid id = contacts[index].Id;

        ConsoleView.PrintInfo("Enter value for field that you only want to edit");
        string name = ConsoleView.GetOptionalContactName("Enter the name: ");
        string phoneNumber = ConsoleView.GetOptionalPhoneNumber("Enter the phone number: ");
        string email = ConsoleView.GetOptionalEmail("Enter the email: ");
        string notes = ConsoleView.GetNotes("Enter the notes (optional): ");
        ConsoleView.PrintInfo(this._service.EditContact(id, name, phoneNumber, email, notes));
        ConsoleView.PrintEmptyLine();
    }

    /// <summary>
    /// Removes the contacts selected.
    /// </summary>
    internal void DeleteContact()
    {
        IReadOnlyList<Contact> contacts = this._service.GetContacts();
        if (contacts.Count == 0)
        {
            ConsoleView.PrintInfo("Nothing to delete\n");
            return;
        }

        ConsoleView.PrintInfo("Select the contact to delete");
        ConsoleView.PrintInfo("Give the index as input");
        ConsoleView.PrintContact(contacts);

        int index = ConsoleView.GetValidContactIndex(contacts.Count);

        Guid id = contacts[index].Id;
        if (this._service.DeleteContact(id))
        {
            ConsoleView.PrintInfo("Contact deleted successfully");
        }
        else
        {
            ConsoleView.PrintInfo("Failed to delete contact");
        }

        ConsoleView.PrintEmptyLine();
    }

    /// <summary>
    /// Search contact by name
    /// </summary>
    internal void SearchContactByName()
    {
        IReadOnlyList<Contact> contacts = this._service.GetContacts();
        if (contacts.Count == 0)
        {
            ConsoleView.PrintInfo("No contact available to search\n");
            return;
        }

        string str = ConsoleView.GetString("Enter the name to search: ");
        IReadOnlyList<Contact> res = this._service.FindByNameContaining(str);
        if (res.Count == 0)
        {
            ConsoleView.PrintInfo("No match found\n");
        }

        ConsoleView.PrintContact(res);
    }

    /// <summary>
    /// Sorts all the contacts by name.
    /// </summary>
    internal void SortContactByName()
    {
        IReadOnlyList<Contact> contacts = this._service.GetSortedByName();
        ConsoleView.PrintContact(contacts);
        ConsoleView.PrintEmptyLine();
    }
}
