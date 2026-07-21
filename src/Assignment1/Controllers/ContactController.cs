using Assignment1.Model;
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
            string input;

            MenuView menu = new ();
            do
            {
                input = menu.DisplayMenu();

                switch (input)
                {
                    case "1":
                        this._view.Display(this.CreateContact());
                        break;

                    case "2":
                        this.ViewContact();
                        break;

                    case "3":
                        this._view.Display(this.EditContact());
                        break;

                    case "4":
                        this._view.Display(this.DeleteContact());
                        break;

                    case "5":
                        this._view.Display(this.SearchContact());
                        break;

                    case "6":
                        this.SortContact();
                        break;

                    case "exit":
                    case "7":
                        Console.WriteLine("Exiting ...");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            }
            while (input.ToLower() != "exit");
        }

        /// <summary>
        /// This creates contact and validates the input
        /// </summary>
        /// <returns>Validation output</returns>
        public string CreateContact()
        {
            Contact contact = this._view.GetContact();
            string validatorOutput = ContactValidator.ValidateContactField(contact);
            if (validatorOutput == string.Empty)
            {
                this._service.CreateContact(contact);
                this._view.DisplayContact(contact);
                return "Contact Created Successfully";
            }
            else
            {
                return validatorOutput;
            }
        }

        /// <summary>
        /// DIsplay the contact
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
        /// Edit Contact
        /// </summary>
        /// <returns>Returns string</returns>
        public string EditContact()
        {
            List<Contact> contacts = this._service.GetContacts();
            if (contacts.Count == 0)
            {
                return "Nothing to Edit";
            }
            else
            {
                Contact? newContact = this._view.EditContact(contacts);
                if (newContact != null)
                {
                    string validatorOutput = ContactValidator.ValidateContactField(newContact);
                    if (validatorOutput == string.Empty)
                    {
                        this._view.DisplayContact(newContact);
                        return this._service.EditContact(newContact);
                    }
                    else
                    {
                        return validatorOutput;
                    }
                }
                else
                {
                    return "Contact Can't Be NULL";
                }
            }
        }

        /// <summary>
        /// Search Contact Controller
        /// </summary>
        /// <returns>String output for operation</returns>
        public string SearchContact()
        {
            string str = this._view.GetSearchText();
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

            int index = this._view.DeleteContact(contacts);

            Guid id = contacts[index].Id;
            return this._service.DeleteContact(id);
        }
    }
}
