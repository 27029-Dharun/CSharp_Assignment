using Assignment1.Model;
using Assignment1.Persistance;
using Assignment1.Validation;

namespace Assignment1.View
{
    /// <summary>
    /// Ui methods are listed in UI class
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Print all the contact list
        /// </summary>
        /// <param name="contacts">Contacts list</param>
        public void PrintContact(List<Contact> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("The Contacts list");
                var i = 1;
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"{i++}. {contact.Name} , {contact.Phone} , {contact.Email} , {contact.Notes} ");
                }
            }
            else
            {
                Console.WriteLine("The Contacts are Empty");
            }
        }

        /// <summary>
        /// Get Contact Info Via console
        /// </summary>
        /// <returns>A contact object</returns>
        public Contact GetContact()
        {
            Console.Write("Enter Your Name: ");
            string name = (Console.ReadLine() ?? string.Empty).Trim();
            while (name == string.Empty)
            {
                Console.WriteLine("Name can't be Empty");
                name = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.Write("Enter Phone number: ");
            string phone = (Console.ReadLine() ?? string.Empty).Trim();
            while (phone == string.Empty)
            {
                Console.WriteLine("Phone Number can't be Empty");
                phone = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.Write("Enter Email Address: ");
            string email = (Console.ReadLine() ?? string.Empty).Trim();
            while (email == string.Empty)
            {
                Console.WriteLine("Email can't be Empty");
                email = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.Write("Enter Notes: ");
            string notes = (Console.ReadLine() ?? string.Empty).Trim();

            return new Contact()
            {
                Name = name,
                Phone = phone,
                Email = email,
                Notes = notes,
            };
        }

        /// <summary>
        /// Edit contact View
        /// </summary>
        /// <param name="contacts">Contact List</param>
        /// <returns>Contact of the Edited one</returns>
        public Contact? EditContact(List<Contact> contacts)
        {
            if (contacts == null || contacts.Count == 0)
            {
                Console.WriteLine("No contacts available to edit.");
                return null;
            }
            else
            {
                Console.WriteLine("Select the contact to edit (enter number):");
                this.PrintContact(contacts);

                int index = -1;
                while (true)
                {
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int parsedValue))
                    {
                        index = parsedValue - 1; // Convert to zero-based index
                        if (ContactValidator.ValidateIndex(index, contacts.Count))
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Enter a valid index.");
                }

                Guid id = contacts[index].Id;

                // Show current details
                Console.WriteLine($"1. Name  : {contacts[index].Name}");
                Console.WriteLine($"2. Email : {contacts[index].Email}");
                Console.WriteLine($"3. Phone : {contacts[index].Phone}");
                Console.WriteLine($"4. Notes : {contacts[index].Notes}");
                Console.WriteLine();
                Console.WriteLine("1 -> Edit Name");
                Console.WriteLine("2 -> Edit Email");
                Console.WriteLine("3 -> Edit Phone");
                Console.WriteLine("4 -> Edit Notes");
                Console.Write("Choose field to edit: ");

                int field;
                while (true)
                {
                    string? option = Console.ReadLine();
                    if (int.TryParse(option, out field) && field >= 1 && field <= 4)
                    {
                        break;
                    }

                    Console.WriteLine("Enter a valid input in range 1 to 4.");
                }

                Console.Write("New Value: ");
                string? value = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Value can't be empty.");
                    return null;
                }

                Contact editedContact = contacts[index];

                switch (field)
                {
                    case 1: editedContact.Name = value; break;
                    case 2: editedContact.Email = value; break;
                    case 3: editedContact.Phone = value; break;
                    case 4: editedContact.Notes = value; break;
                }

                return editedContact;
            }
        }

        /// <summary>
        /// This is delete contact View
        /// </summary>
        /// <param name="contacts">Contact list to display </param>
        /// <returns>Index to delete</returns>
        public int DeleteContact(List<Contact> contacts)
        {
            Console.WriteLine("Select the contact to Delete");
            Console.WriteLine("Give the number as input");
            this.PrintContact(contacts);

            int valid = 0;
            int index = -1;
            while (valid != 1)
            {
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int parsedValue))
                {
                    index = parsedValue - 1;
                    if (ContactValidator.ValidateIndex(index, contacts.Count))
                    {
                        valid = 1;
                    }
                }

                if (valid == 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }

            return index;
        }

        /// <summary>
        /// Search Contact
        /// </summary>
        /// <returns>Returns The text string match pattern</returns>
        public string GetSearchText()
        {
            Console.Write("Enter the Name to search : ");
            string str = (Console.ReadLine() ?? string.Empty).Trim();

            return str;
        }

        /// <summary>
        /// This class Displays the String
        /// </summary>
        /// <param name="str">Result of all operations</param>
        public void Display(string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// Display the Edited Contact
        /// </summary>
        /// <param name="contact">Contact object to Print</param>
        public void DisplayContact(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.Phone}");
            Console.WriteLine($"Notes: {contact.Notes}");
        }
    }
}