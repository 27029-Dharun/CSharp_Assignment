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
            ContactManager contactManger = new ContactManager();
            try
            {
                string msg = contactManger.CreateContact(name, phone, email, notes);
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
            ContactManager contactManager = new ContactManager();
            List<ContactInfo> contacts = contactManager.DisplayContact();
            DisplayClass displayClass = new DisplayClass();
            displayClass.PrintContact(contacts);
        }

        /// <summary>
        /// Edit Option
        /// </summary>
        public void EditContact()
        {
            ContactManager contactManager = new ContactManager();

            List<ContactInfo> contacts = contactManager.DisplayContact();
            if (contacts.Count == 0)
            {
                Console.WriteLine("Nothing to Edit");
            }

            Console.WriteLine("Select the contact to edit");
            Console.WriteLine("Give the number as input");
            DisplayClass displayClass = new DisplayClass();
            displayClass.PrintContact(contacts);

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
            string value = Console.ReadLine();

            if (contactManager.EditContact(id, field, value))
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
            ContactManager contactManager = new ContactManager();
            List<ContactInfo> contacts = contactManager.DisplayContact();
            if (contacts.Count == 0)
            {
                Console.WriteLine("NOthing to Edit");
            }

            Console.WriteLine("Select the contact to Delete");
            Console.WriteLine("Give the number as input");
            DisplayClass displayClass = new DisplayClass();
            displayClass.PrintContact(contacts);

            int index = int.Parse(Console.ReadLine()) - 1;
            Guid id = contacts[index].Id;
            try
            {
                contactManager.DeleteContact(id);
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
            DisplayClass display = new DisplayClass();
            var str = Console.ReadLine().Trim();

            ContactManager contactManger = new();
            List<ContactInfo> res = contactManger.SearchContact(str);
            if (res.Count == 0)
            {
                Console.WriteLine("No Match Found");
            }
            else
            {
                Console.WriteLine("Matched Contacts");
                display.PrintContact(res);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Sort all the contact
        /// </summary>
        public void SortContact()
        {
            ContactManager contactManger = new();
            contactManger.SortContactByName();
            List<ContactInfo> contacts = contactManger.DisplayContact();
            DisplayClass display = new DisplayClass();
            display.PrintContact(contacts);
        }
    }
}