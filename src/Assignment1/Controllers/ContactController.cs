using Assignment1.Model;
using Assignment1.Models;
using Assignment1.Services;
using Assignment1.Validation;
using Assignment1.View;

namespace Assignment1.Controllers
{
    /// <summary>
    /// Contact controller
    /// </summary>
    internal class ContactController
    {
        private ConsoleView _view = new ConsoleView();

        private ContactService _service = new ContactService();

        /// <summary>
        /// Menu OPtion display method
        /// </summary>
        public void Run()
        {
            int input;
            do
            {
                input = MenuView.DisplayMenu();
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
                        ConsoleView.PrintInfo(this.SearchContact());
                        break;

                    case (int)Enums.ContactManager.Sort:
                        this.SortContact();
                        break;

                    case (int)Enums.ContactManager.Exit:
                        ConsoleView.PrintInfo("Exiting ...");
                        return;

                    default:
                        ConsoleView.PrintInfo("Please enter a valid input");
                        break;
                }
            }
            while (input != (int)Enums.ContactManager.Exit);
        }

        /// <summary>
        /// This creates contact and validates the input
        /// </summary>
        /// <returns>Validation output</returns>
        public string CreateContact()
        {
            string name = ConsoleView.GetString("Enter name: ");
            string phone = ConsoleView.GetString("Enter Phone Number: ");
            string email = ConsoleView.GetString("Enter Email Address: ");
            string notes = ConsoleView.GetOptionalString("Enter Notes: ");

            string validatorOutput = ContactValidator.ValidateContactFields(name, phone, email, notes);
            if (validatorOutput != string.Empty)
            {
                return validatorOutput;
            }

            Contact? contact = this._service.CreateContact(name, phone, email, notes);
            if (contact == null)
            {
                return "Phone number already exists";
            }

            Console.WriteLine();
            ConsoleView.DisplayContact(contact);
            return "Contact Created Successfully";
        }

        /// <summary>
        /// Display the contact
        /// </summary>
        public void ViewContact()
        {
            List<Contact> contacts = this._service.GetContacts();
            this._view.PrintContact(contacts);
        }

        /// <summary>
        /// Sort all the contact
        /// </summary>
        public void SortContact()
        {
            this._service.SortContactByName();
            List<Contact> contacts = this._service.GetContacts();
            this._view.PrintContact(contacts);
        }

        /// <summary>
        /// This edits the contact
        /// </summary>
        public void EditContact()
        {
            var contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                ConsoleView.PrintInfo("Nothing to Edit");
                return;
            }

            ConsoleView.PrintInfo("Select the contact to edit (enter number): ");
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
                    case 1: updatedName = newValue; break;
                    case 2: updatedEmail = newValue; break;
                    case 3: updatedPhone = newValue; break;
                    case 4: updatedNotes = newValue; break;
                }

                string errorOutput = ContactValidator.ValidateContactFields(updatedName, updatedPhone, updatedEmail, updatedNotes);

                if (string.IsNullOrEmpty(errorOutput))
                {
                    ConsoleView.PrintInfo(this._service.EditContact(targetContact.Id, updatedName, updatedPhone, updatedEmail, updatedNotes));
                    break;
                }

                ConsoleView.PrintInfo($"{errorOutput} Please try again.");
            }
        }

        /// <summary>
        /// Search Contact Controller
        /// </summary>
        /// <returns>String output for operation</returns>
        public string SearchContact()
        {
            string str = ConsoleView.GetString("Enter the name to search: ");
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
            ConsoleView.PrintInfo("Give the number as input");
            this._view.PrintContact(contacts);

            int index = this.GetValidContactIndex(contacts.Count);

            Guid id = contacts[index].Id;
            return this._service.DeleteContact(id);
        }

        /// <summary>
        /// This validates the contact index
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
        /// This method gets the valid field to edit
        /// </summary>
        /// <returns>Integer field to edit</returns>
        private int GetValidFieldOption()
        {
            while (true)
            {
                int option = ConsoleView.GetInteger("1 -> Edit Name\n2 -> Edit Email\n3 -> Edit Phone\n4 -> Edit Notes\nChoose field to edit: ");
                if (option >= 1 && option <= 4)
                {
                    return option;
                }

                ConsoleView.PrintInfo("Enter a valid input in range 1 to 4.");
            }
        }
    }
}
