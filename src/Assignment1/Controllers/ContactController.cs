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
    private readonly ConsoleView _consoleView;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactController"/> class.
    /// </summary>
    /// <param name="view">Views object</param>
    /// <param name="service">Services object</param>
    internal ContactController(ConsoleView view, ContactService service)
    {
        this._service = service;
        this._consoleView = view;
    }

    /// <summary>
    /// Loops and gets menu as input.
    /// </summary>
    internal void HandleMenuOption()
    {
        this._consoleView.PrintInfo("Contact Manager Application");
        ContactManagerMenuOption option;
        while (true)
        {
            option = (ContactManagerMenuOption)this._consoleView.GetInteger(
                "Welcome to contact manager console application\n" +
                "1. Create new contact\n" +
                "2. View contact\n" +
                "3. Edit contact\n" +
                "4. Delete contact\n" +
                "5. Search contact by name\n" +
                "6. Sort contact by name\n" +
                "7. Exit\n" +
                "Choose an option: ");

            this._consoleView.Clear();

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
                    this._consoleView.PrintInfo("Please enter an input in range 1 - 7");
                    break;
            }
        }
    }

    /// <summary>
    /// Creates contact and validates the option.
    /// </summary>
    internal void CreateContact()
    {
        string name = this._consoleView.GetContactName("Enter name: ");
        string phoneNumber = this._consoleView.GetPhoneNumber("Enter phone number: ");
        string email = this._consoleView.GetEmail("Enter email address: ");
        string notes = this._consoleView.GetOptionalNotes("Enter notes (optional): ");

        this._consoleView.PrintInfo(this._service.CreateContact(name, phoneNumber, email, notes));
        this._consoleView.PrintEmptyLine();
    }

    /// <summary>
    /// Displays the all contacts.
    /// </summary>
    internal void ViewContact()
    {
        IReadOnlyList<Contact> contacts = this._service.GetContacts();
        this._consoleView.PrintContact(contacts);
    }

    /// <summary>
    /// Edits the contact selected.
    /// </summary>
    internal void EditContact()
    {
        var contacts = this._service.GetContacts();
        if (contacts.Count == 0)
        {
            this._consoleView.PrintInfo("Nothing to edit\n");
            return;
        }

        this._consoleView.PrintInfo("Select the contact to edit: ");
        this._consoleView.PrintContact(contacts);
        int index = this._consoleView.GetValidContactIndex(contacts.Count);
        Guid id = contacts[index].Id;

        this._consoleView.PrintInfo("Enter value for field that you only want to edit");
        string name = this._consoleView.GetOptionalContactName("Enter the name: ");
        string phoneNumber = this._consoleView.GetOptionalPhoneNumber("Enter the phone number: ");
        string email = this._consoleView.GetOptionalEmail("Enter the email: ");
        string notes = this._consoleView.GetOptionalNotes("Enter the notes (optional): ");
        this._consoleView.PrintInfo(this._service.EditContact(id, name, phoneNumber, email, notes));
        this._consoleView.PrintEmptyLine();
    }

    /// <summary>
    /// Removes the contacts selected.
    /// </summary>
    internal void DeleteContact()
    {
        IReadOnlyList<Contact> contacts = this._service.GetContacts();
        if (contacts.Count == 0)
        {
            this._consoleView.PrintInfo("Nothing to delete\n");
            return;
        }

        this._consoleView.PrintInfo("Select the contact to delete");
        this._consoleView.PrintContact(contacts);

        int index = this._consoleView.GetValidContactIndex(contacts.Count);

        Guid id = contacts[index].Id;
        if (this._service.DeleteContact(id))
        {
            this._consoleView.PrintInfo("Contact deleted successfully");
        }
        else
        {
            this._consoleView.PrintInfo("Failed to delete contact");
        }

        this._consoleView.PrintEmptyLine();
    }

    /// <summary>
    /// Search contact by name
    /// </summary>
    internal void SearchContactByName()
    {
        IReadOnlyList<Contact> contacts = this._service.GetContacts();
        if (contacts.Count == 0)
        {
            this._consoleView.PrintInfo("No contact available to search\n");
            return;
        }

        string str = this._consoleView.GetString("Enter the name to search: ");
        IReadOnlyList<Contact> res = this._service.FindByNameContaining(str);
        if (res.Count == 0)
        {
            this._consoleView.PrintInfo("No match found\n");
            return;
        }

        this._consoleView.PrintContact(res);
    }

    /// <summary>
    /// Sorts all the contacts by name.
    /// </summary>
    internal void SortContactByName()
    {
        IReadOnlyList<Contact> contacts = this._service.GetSortedByName();
        this._consoleView.PrintContact(contacts);
        this._consoleView.PrintEmptyLine();
    }
}
