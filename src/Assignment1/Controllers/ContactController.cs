using System.Reflection;
using Assignment1.Model;
using Assignment1.Models;
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
                    case (int)Enums.ContactManager.Create:
                        ConsoleView.PrintInfo(this.CreateContact());
                        break;

                    case (int)Enums.ContactManager.View:
                        this.ViewContact();
                        break;

                    case (int)Enums.ContactManager.Edit:
                        this.EditContact();
                        break;

                    case (int)Enums.ContactManager.Delete:
                        ConsoleView.PrintInfo(this.DeleteContact());
                        break;

                    case (int)Enums.ContactManager.Search:
                        ConsoleView.PrintInfo(this.SearchContactByName());
                        break;

                    case (int)Enums.ContactManager.Sort:
                        this.SortContactByName();
                        break;

                    case (int)Enums.ContactManager.Exit:
                        ConsoleView.PrintInfo("Exiting ...");
                        return;

                    default:
                        ConsoleView.PrintInfo("Please enter an input in range 1 - 7");
                        break;
                }
            }
            while (input != (int)Enums.ContactManager.Exit);

            ConsoleView.PrintInfo("Enter a Key to Exit");
        }

        /// <summary>
        /// Creates contact and validates the input.
        /// </summary>
        /// <returns>Validation output</returns>
        public string CreateContact()
        {
            string name = ConsoleView.GetString("Enter name: ");
            string phone = ConsoleView.GetString("Enter Phone Number: ");
            string email = ConsoleView.GetString("Enter Email Address: ");
            string notes = ConsoleView.GetOptionalString("Enter Notes: ");
            if (notes == string.Empty)
            {
                notes = "Not Specified";
            }

            string validatorOutput = ContactValidator.ValidateContactFields(name, phone, email, notes);
            if (validatorOutput != string.Empty)
            {
                return validatorOutput;
            }

            Contact? contact = this._service.CreateContact(name, phone, email, notes);
            if (contact == null)
            {
                return "Phone number and Name should be Unique";
            }

            Console.WriteLine();
            ConsoleView.DisplayContact(contact);
            return "Contact Created Successfully\n";
        }

        /// <summary>
        /// Displays the contact list.
        /// </summary>
        public void ViewContact()
        {
            List<Contact> contacts = this._service.GetContacts();
            this._view.PrintContact(contacts);
        }

        /// <summary>
        /// Sorts all the contact by name.
        /// </summary>
        public void SortContactByName()
        {
            this._service.SortContactByName();
            List<Contact> contacts = this._service.GetContacts();
            this._view.PrintContact(contacts);
        }

        /// <summary>
        /// Edits the contact by index.
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
            int index = this.GetValidContactIndex(contacts.Count);
            Contact targetContact = contacts[index];

            string updatedName = string.Empty;
            string updatedEmail = string.Empty;
            string updatedPhone = string.Empty;
            string updatedNotes = string.Empty;

            if (targetContact.Name != null && targetContact.Email != null && targetContact.Phone != null && targetContact.Notes != null)
            {
                updatedName = targetContact.Name;
                updatedEmail = targetContact.Email;
                updatedPhone = targetContact.Phone;
                updatedNotes = targetContact.Notes;
            }

            ConsoleView.DisplayContact(targetContact);
            int fieldOption = this.GetValidFieldOption();

            // Loop until user input passes validation rules
            while (true)
            {
                string newValue = ConsoleView.GetString("Enter the new value: ");

                switch (fieldOption)
                {
                    case 1:
                        updatedName = newValue;
                        break;
                    case 2:
                        updatedPhone = newValue;
                        break;
                    case 3:
                        updatedEmail = newValue;
                        break;
                    case 4:
                        updatedNotes = newValue;
                        break;
                }

                string errorOutput = ContactValidator.ValidateContactFields(updatedName, updatedPhone, updatedEmail, updatedNotes);

                if (string.IsNullOrEmpty(errorOutput) && targetContact.Phone != null && targetContact.Name != null)
                {
                    ConsoleView.PrintInfo(this._service.EditContact(targetContact.Id, updatedName, updatedPhone, updatedEmail, updatedNotes, targetContact.Phone, targetContact.Name));
                    break;
                }

                ConsoleView.PrintInfo($"{errorOutput} Please try again.");
            }
        }

        /// <summary>
        /// Search Contact By Name
        /// </summary>
        /// <returns>String output for operation</returns>
        public string SearchContactByName()
        {
            string str = ConsoleView.GetOptionalString("Enter the name to search: ");
            List<Contact> res = this._service.SearchContactByName(str);
            if (res.Count == 0)
            {
                return "No Match Found";
            }

            this._view.PrintContact(res);
            return string.Empty;
        }

        /// <summary>
        /// Delete the contact
        /// </summary>
        /// <returns>String output of operation</returns>
        public string DeleteContact()
        {
            List<Contact> contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                return "Nothing to Delete";
            }

            ConsoleView.PrintInfo("Select the contact to Delete");
            ConsoleView.PrintInfo("Give the index as input");
            this._view.PrintContact(contacts);

            int index = this.GetValidContactIndex(contacts.Count);

            Guid id = contacts[index].Id;
            return this._service.DeleteContact(id);
        }

        /// <summary>
        /// Validates the contact index
        /// </summary>
        /// <param name="count">This is the contact </param>
        /// <returns>this returns the </returns>
        private int GetValidContactIndex(int count)
        {
            while (true)
            {
                int input = ConsoleView.GetInteger("Select the contact: ");
                int zeroBasedIndex = input - 1;
                if (ContactValidator.ValidateIndex(zeroBasedIndex, count))
                {
                    return zeroBasedIndex;
                }

                ConsoleView.PrintInfo("Enter a valid index.");
            }
        }

        /// <summary>
        /// Gets the valid field to edit
        /// </summary>
        /// <returns>Integer field to edit</returns>
        private int GetValidFieldOption()
        {
            while (true)
            {
                int option = ConsoleView.GetInteger("1. Edit Name\n2. Edit Phone\n3. Edit Email\n4. Edit Notes\nChoose field to edit: ");
                if (option >= 1 && option <= 4)
                {
                    return option;
                }

                ConsoleView.PrintInfo("Enter a valid input in range 1 to 4.");
            }
        }
    }
}
