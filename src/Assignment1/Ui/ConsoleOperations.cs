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
            var name = Console.ReadLine().Trim();
            Console.Write("Enter Phone number: ");
            var phone = Console.ReadLine().Trim();
            Console.Write("Enter Email Address: ");
            var email = Console.ReadLine().Trim();
            Console.Write("Enter Notes: ");
            var notes = Console.ReadLine().Trim();
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
        /// DIsplay the contact
        /// </summary>
        public void ViewContact()
        {
            List<ContactInfo> contacts = this._contactManager.DisplayContact();
            _display.PrintContact(contacts);
        }

        /// <summary>
        /// Edit Option
        /// </summary>
        public void EditContact()
        {
            List<ContactInfo> contacts = _contactManager.DisplayContact();
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nothing to Edit");
            }

            Console.WriteLine("Select the contact to edit");
            Console.WriteLine("Give the number as input");
            _display.PrintContact(contacts);

            int valid = 0;
            int index = 0;
            while (valid != 1)
            {
                index = int.Parse(Console.ReadLine()) - 1;
                if (index >= 0 && contacts.Count > index)
                {
                    valid = 1;
                }
                else
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
            int field = -1;
            while (true)
            {
                field = int.Parse(Console.ReadLine());
                if (field >= 1 && field <= 4)
                {
                    break;
                }

                Console.WriteLine("Enter a valid input in range 1 to 4");
            }

            Console.Write("New Value : ");
            string? value = Console.ReadLine();

            if (this._contactManager.EditContact(id, field, value))
            {
                Console.WriteLine("Updated Successfully.");
            }
            else
            {
                Console.WriteLine("Contact Not Found.");
            }
        }

        /// <summary>
        /// Delete the contact
        /// </summary>
        public void DeleteContact()
        {
            List<ContactInfo> contacts = this._contactManager.DisplayContact();
            if (contacts.Count == 0)
            {
                Console.WriteLine("NOthing to Edit");
            }

            Console.WriteLine("Select the contact to Delete");
            Console.WriteLine("Give the number as input");
            this._display.PrintContact(contacts);

            int index = int.Parse(Console.ReadLine()) - 1;
            Guid id = contacts[index].Id;
            try
            {
                _contactManager.DeleteContact(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Search Contact
        /// </summary>
        public void SearchContacts()
        {
            Console.Write("Enter the Name to search : ");
            var str = Console.ReadLine().Trim();

            List<ContactInfo> res = _contactManager.SearchContact(str);
            if (res.Count == 0)
            {
                Console.WriteLine("No Match Found");
            }
            else
            {
                Console.WriteLine("Matched Contacts");
                _display.PrintContact(res);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Sort all the contact
        /// </summary>
        public void SortContact()
        {
            _contactManager.SortContactByName();
            List<ContactInfo> contacts = _contactManager.DisplayContact();
            _display.PrintContact(contacts);
        }
    }
}