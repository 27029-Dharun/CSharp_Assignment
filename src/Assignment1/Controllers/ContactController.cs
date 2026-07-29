using Assignment1.Model;
using Assignment1.Services;
using Assignment1.Validation;
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
            int input;
            do
            {
                input = ConsoleView.GetInteger("1. Create New Contact\n2. View Contact\n3. Edit contact\n4. Delete Contact\n5. Search Contact\n6. Sort contact\n7. Exit\nChoose a option: ");
                Console.Clear();

                switch (input)
                {
                    case (int)ContactManagerMenuOption.Create:
                        ConsoleView.PrintInfo(this.CreateContact());
                        break;

                    case (int)ContactManagerMenuOption.View:
                        this.ViewContact();
                        break;

                    case (int)ContactManagerMenuOption.Edit:
                        this.EditContact();
                        break;

                    case (int)ContactManagerMenuOption.Delete:
                        ConsoleView.PrintInfo(this.DeleteContact());
                        break;

                    case (int)ContactManagerMenuOption.Search:
                        ConsoleView.PrintInfo(this.SearchContactByName());
                        break;

                    case (int)ContactManagerMenuOption.Sort:
                        this.SortContactByName();
                        break;

                    case (int)ContactManagerMenuOption.Exit:
                        ConsoleView.PrintInfo("Exiting...");
                        return;

                    default:
                        ConsoleView.PrintInfo("Please enter an input in range 1 - 7");
                        break;
                }
            }
            while (input != (int)ContactManagerMenuOption.Exit);

            ConsoleView.PrintInfo("Enter a Key to Exit");
        }

        /// <summary>
        /// Creates contact and validates the input.
        /// </summary>
        /// <returns>Validation output</returns>
        public string CreateContact()
        {
            string name = ConsoleView.GetString("Enter name: ");
            string phoneNumber = ConsoleView.GetString("Enter Phone Number: ");
            string email = ConsoleView.GetString("Enter Email Address: ");
            string notes = ConsoleView.GetOptionalString("Enter Notes: ");

            // Default value of the Notes if not entered
            if (notes == string.Empty)
            {
                notes = "Not Specified";
            }

            string validatorOutput = ContactValidator.IsValidContactFields(name, phoneNumber, email, notes);
            if (validatorOutput != string.Empty)
            {
                return validatorOutput;
            }

            Contact? contact = this._service.CreateContact(name, phoneNumber, email, notes);
            if (contact == null)
            {
                return "Phone Number and Name should be Unique";
            }

            Console.WriteLine();
            ConsoleView.DisplayContact(contact);
            return "Contact Created Successfully\n";
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
        }

        /// <summary>
        /// Edits the contact selected.
        /// </summary>
        public void EditContact()
        {
            var contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                ConsoleView.PrintInfo("Nothing to Edit");
                return;
            }

            ConsoleView.PrintInfo("Select the contact to edit (enter index): ");
            this._view.PrintContact(contacts);
            int index = this._view.GetValidContactIndex(contacts.Count);
            Guid id = contacts[index].Id;
            string? exisitingPhone = contacts[index].PhoneNumber;
            string? exisitingName = contacts[index].Name;

            ConsoleView.PrintInfo("Enter value for field that you only want to Edit");
            string name = ConsoleView.GetOptionalString("Enter the Name: ");
            string phoneNumber = ConsoleView.GetOptionalString("Enter the Phone Number: ");
            string email = ConsoleView.GetOptionalString("Enter the Email: ");
            string notes = ConsoleView.GetOptionalString("Enter the Notes: ");
            this._service.EditContact(id, name, phoneNumber, email, notes, exisitingPhone, exisitingName);
            ConsoleView.PrintInfo("Product Edited Successfully");
        }

        /// <summary>
        /// Search Contact By Name
        /// </summary>
        /// <returns>String output for operation</returns>
        public string SearchContactByName()
        {
            string str = ConsoleView.GetOptionalString("Enter the name to search: ");
            IReadOnlyList<Contact> res = this._service.FindByNameContaining(str);
            if (res.Count == 0)
            {
                return "No Match Found";
            }

            this._view.PrintContact(res);
            return string.Empty;
        }

        /// <summary>
        /// Removes the contacts selected.
        /// </summary>
        /// <returns>String output of operation</returns>
        public string DeleteContact()
        {
            IReadOnlyList<Contact> contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                return "Nothing to Delete";
            }

            ConsoleView.PrintInfo("Select the contact to Delete");
            ConsoleView.PrintInfo("Give the index as input");
            this._view.PrintContact(contacts);

            int index = this._view.GetValidContactIndex(contacts.Count);

            Guid id = contacts[index].Id;
            return this._service.DeleteContact(id);
        }
    }
}
