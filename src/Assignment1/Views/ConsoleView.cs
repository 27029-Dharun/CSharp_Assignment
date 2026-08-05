using Assignment1.Model;

namespace Assignment1.View
{
    /// <summary>
    /// Ui methods are listed in UI class
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Gets the Integer input.
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        public static string GetString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            while (input == string.Empty)
            {
                Console.WriteLine("Field can't be empty");
                input = (Console.ReadLine() ?? string.Empty).Trim();
            }

            return input;
        }

        /// <summary>
        /// Prints the empty line
        /// </summary>
        public static void PrintEmptyLine() => Console.WriteLine();

        /// <summary>
        /// Displays the Edited Contact.
        /// </summary>
        /// <param name="contact">Contact object to Print</param>
        public static void DisplayContact(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"Notes: {contact.Notes}");
        }

        /// <summary>
        /// Gets the string input.
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>string value that we got as input</returns>
        public static string GetOptionalString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            return input;
        }

        /// <summary>
        /// Gets the Integer input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        public static int GetInteger(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Integer");
            }

            return input;
        }

        /// <summary>
        /// Prints all the contact list
        /// </summary>
        /// <param name="contacts">Contacts list</param>
        public void PrintContact(IReadOnlyList<Contact> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("The Contacts list");
                var i = 1;
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"{i++}. {contact.Name} , {contact.PhoneNumber} , {contact.Email} , {contact.Notes} ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The Contacts are empty\n");
            }
        }

        /// <summary>
        /// Prints the input string
        /// </summary>
        /// <param name="message">The string to be printed</param>
        internal static void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Gets valid Contact Index
        /// </summary>
        /// <param name="count">Count of the contacts available</param>
        /// <returns>Integer value</returns>
        internal int GetValidContactIndex(int count)
        {
            while (true)
            {
                int input = ConsoleView.GetInteger("Select the contact: ");
                int zeroBasedIndex = input - 1;
                if (zeroBasedIndex >= 0 && count > zeroBasedIndex)
                {
                    return zeroBasedIndex;
                }

                Console.WriteLine("Enter a valid index. Maximum Value: " + (count - 1));
            }
        }

        /// <summary>
        /// Gets the valid field to edit
        /// </summary>
        /// <returns>Integer field to edit</returns>
        internal int GetValidFieldOption()
        {
            while (true)
            {
                int option = ConsoleView.GetInteger("1. Edit Name\n2. Edit PhoneNumber\n3. Edit Email\n4. Edit Notes\nChoose field to edit: ");
                if (option >= 1 && option <= 4)
                {
                    return option;
                }

                Console.WriteLine("Enter a valid input in range 1 to 4.");
            }
        }
    }
}