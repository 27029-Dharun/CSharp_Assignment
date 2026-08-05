using Assignment1.Model;
using Assignment1.Services;
using Assignment1.View;

namespace Assignment1.Controllers
{
    /// <summary>
    /// Contact controller class.
    /// </summary>
    internal class ContactController
    {
        private ConsoleView _view;
        private ContactService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class.
        /// </summary>
        /// <param name="view">View object</param>
        /// <param name="service">Services object</param>
        public ContactController(ConsoleView view, ContactService service)
        {
            this._view = view;
            this._service = service;
        }

        /// <summary>
        /// Runs the contact manager.
        /// </summary>
        public void RunContactManager()
        {
            ConsoleView.PrintInfo("Contact Manager Application");
            ContactManagerMenuOption option;
            do
            {
                option = (ContactManagerMenuOption)ConsoleView.GetInteger("1. Create new contact\n2. View contact\n3. Edit contact\n4. Delete contact\n5. Search contact by name\n6. Sort contact by name\n7. Exit\nChoose an option: ");
                Console.Clear();

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
        public void CreateContact()
        {
            string name = ConsoleView.GetString("Enter name: ");
            string phoneNumber = ConsoleView.GetString("Enter phone number: ");
            string email = ConsoleView.GetString("Enter email address: ");
            string notes = ConsoleView.GetOptionalString("Enter notes: ");

            ConsoleView.PrintInfo(this._service.CreateContact(name, phoneNumber, email, notes));
            ConsoleView.PrintEmptyLine();
        }

        /// <summary>
        /// Displays the all contacts.
        /// </summary>
        public void ViewContact()
        {
            IReadOnlyList<Contact> contacts = this._service.GetContacts();
            this._view.PrintContact(contacts);
        }

        /// <summary>
        /// Sorts all the contacts by name.
        /// </summary>
        public void SortContactByName()
        {
            IReadOnlyList<Contact> contacts = this._service.GetSortedByName();
            this._view.PrintContact(contacts);
            ConsoleView.PrintEmptyLine();
        }

        /// <summary>
        /// Edits the contact selected.
        /// </summary>
        public void EditContact()
        {
            var contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                ConsoleView.PrintInfo("Nothing to edit\n");
                return;
            }

            ConsoleView.PrintInfo("Select the contact to edit (enter index): ");
            this._view.PrintContact(contacts);
            int index = this._view.GetValidContactIndex(contacts.Count);
            Guid id = contacts[index].Id;

            ConsoleView.PrintInfo("Enter value for field that you only want to edit");
            string name = ConsoleView.GetOptionalString("Enter the name: ");
            string phoneNumber = ConsoleView.GetOptionalString("Enter the phone number: ");
            string email = ConsoleView.GetOptionalString("Enter the email: ");
            string notes = ConsoleView.GetOptionalString("Enter the notes: ");
            ConsoleView.PrintInfo(this._service.EditContact(id, name, phoneNumber, email, notes));
            ConsoleView.PrintEmptyLine();
        }

        /// <summary>
        /// Search Contact By Name
        /// </summary>
        public void SearchContactByName()
        {
            IReadOnlyList<Contact> contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                ConsoleView.PrintInfo("No contact available to search\n");
                return;
            }

            string str = ConsoleView.GetOptionalString("Enter the name to search: ");
            IReadOnlyList<Contact> res = this._service.FindByNameContaining(str);
            if (res.Count == 0)
            {
                ConsoleView.PrintInfo("No match found\n");
            }

            this._view.PrintContact(res);
        }

        /// <summary>
        /// Removes the contacts selected.
        /// </summary>
        public void DeleteContact()
        {
            IReadOnlyList<Contact> contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                ConsoleView.PrintInfo("Nothing to delete\n");
                return;
            }

            ConsoleView.PrintInfo("Select the contact to delete");
            ConsoleView.PrintInfo("Give the index as input");
            this._view.PrintContact(contacts);

            int index = this._view.GetValidContactIndex(contacts.Count);

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
    }
}
