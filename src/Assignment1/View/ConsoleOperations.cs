using Assignment1.Model;
using Assignment1.Persistance;
using Assignment1.Services;
using Assignment1.Ui;

namespace Assignments1
{
    /// <summary>
    /// Ui methods are listed in UI class
    /// </summary>
    internal class ConsoleOperations
    {
        private ContactManager _contactManager = new ContactManager();
        private DisplayClass _display = new DisplayClass();

        /// <summary>
        /// Get Contact Info Via console
        /// </summary>
        public void GetContact()
        {
            Console.Write("Enter Your Name: ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();

            Console.Write("Enter Phone number: ");
            string phone = (Console.ReadLine() ?? string.Empty).Trim();

            Console.Write("Enter Email Address: ");
            string email = (Console.ReadLine() ?? string.Empty).Trim();

            Console.Write("Enter Notes: ");
            string notes = (Console.ReadLine() ?? string.Empty).Trim();
            try
            {
                string msg = this._contactManager.CreateContact(name, phone, email, notes);
                Console.WriteLine(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Index Validation
        /// </summary>
        /// <param name="index">Index of contact</param>
        /// <returns>Return boolean</returns>
        public bool ValidateIndex(int index)
        {
            List<ContactInfo> contacts = this._contactManager.GetContacts();
            if (index >= 0 && contacts.Count > index)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// DIsplay the contact
        /// </summary>
        public void ViewContact()
        {
            List<ContactInfo> contacts = this._contactManager.GetContacts();
            this._display.PrintContact(contacts);
        }

        /// <summary>
        /// Edit Option
        /// </summary>
        public void EditContact()
        {
            List<ContactInfo> contacts = this._contactManager.GetContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nothing to Edit");
            }
            else
            {
                Console.WriteLine("Select the contact to edit");
                Console.WriteLine("Give the number as input");
                this._display.PrintContact(contacts);

                int valid = 0;
                int index = -1;

                while (valid != 1)
                {
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int parsedValue))
                    {
                        index = parsedValue - 1;
                        if (this.ValidateIndex(index))
                        {
                            valid = 1;
                        }
                    }

                    if (valid == 0)
                    {
                        Console.WriteLine("Enter a valid Index");
                    }
                }

                Guid id = contacts[index].Id;
                Console.WriteLine("1.Name" + ": " + contacts[index].Name);
                Console.WriteLine("2.Email" + ": " + contacts[index].Email);
                Console.WriteLine("3.Phone" + ": " + contacts[index].Phone);
                Console.WriteLine("4.Notes" + ": " + contacts[index].Notes);
                Console.WriteLine();
                Console.WriteLine("1 -> Edit Name");
                Console.WriteLine("2 -> Edit Email");
                Console.WriteLine("3 -> Edit Phone");
                Console.WriteLine("4 -> Edit Notes");
                Console.Write("Choose Field To edit : ");
                int field;
                while (true)
                {
                    string? option = Console.ReadLine();
                    int.TryParse(option, out field);
                    if (field >= 1 && field <= 4)
                    {
                        break;
                    }

                    Console.WriteLine("Enter a valid input in range 1 to 4");
                }

                Console.Write("New Value : ");
                string? value = Console.ReadLine();
                if (value == null)
                {
                    Console.WriteLine("Value con't be null");
                }
                else
                {
                    string result = this._contactManager.EditContact(id, field, value);
                    Console.WriteLine(result);
                }
            }
        }

        /// <summary>
        /// Delete the contact
        /// </summary>
        public void DeleteContact()
        {
            List<ContactInfo> contacts = this._contactManager.GetContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nothing to Delete");
            }
            else
            {
                Console.WriteLine("Select the contact to Delete");
                Console.WriteLine("Give the number as input");
                this._display.PrintContact(contacts);

                int valid = 0;
                int index = -1;
                while (valid != 1)
                {
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int parsedValue))
                    {
                        index = parsedValue - 1;
                        if (this.ValidateIndex(index))
                        {
                            valid = 1;
                        }
                    }

                    if (valid == 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                }

                Guid id = contacts[index].Id;
                Console.WriteLine(this._contactManager.DeleteContact(id));
            }
        }

        /// <summary>
        /// Search Contact
        /// </summary>
        public void SearchContacts()
        {
            Console.Write("Enter the Name to search : ");
            string str = (Console.ReadLine() ?? string.Empty).Trim();

            List<ContactInfo> res = this._contactManager.SearchContact(str);
            if (res.Count == 0)
            {
                Console.WriteLine("No Match Found");
            }
            else
            {
                Console.WriteLine("Matched Contacts");
                this._display.PrintContact(res);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Sort all the contact
        /// </summary>
        public void SortContact()
        {
            this._contactManager.SortContactByName();
            List<ContactInfo> contacts = this._contactManager.GetContacts();
            this._display.PrintContact(contacts);
        }
    }
}