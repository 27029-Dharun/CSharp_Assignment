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
        /// This methos gets the Integer input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        public static string GetString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            while (input == string.Empty)
            {
                Console.WriteLine("Field can't be Empty");
                input = (Console.ReadLine() ?? string.Empty).Trim();
            }

            return input;
        }

        /// <summary>
        /// Display the Edited Contact
        /// </summary>
        /// <param name="contact">Contact object to Print</param>
        public static void DisplayContact(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.Phone}");
            Console.WriteLine($"Notes: {contact.Notes}");
        }

        /// <summary>
        /// This methos gets the Integer input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        public static string GetOptionalString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            return input;
        }

        /// <summary>
        /// This methos gets the Integer input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        public static int GetInteger(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a positive Double value");
            }

            return input;
        }

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

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The Contacts are Empty\n");
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
        /// This method prints the input
        /// </summary>
        /// <param name="v">The string to be printed</param>
        internal static void PrintInfo(string v)
        {
            Console.WriteLine(v);
        }

        /// <summary>
        /// This is delete contact View
        /// </summary>
        /// <param name="contacts">Contact list to display </param>
        /// <returns>Index to delete</returns>
        internal int DeleteContact(List<Contact> contacts)
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
        internal string GetSearchText()
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
    }
}