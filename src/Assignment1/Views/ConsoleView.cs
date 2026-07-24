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
                Console.WriteLine("Please enter a Integer");
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
        /// This method prints the input
        /// </summary>
        /// <param name="v">The string to be printed</param>
        internal static void PrintInfo(string v)
        {
            Console.WriteLine(v);
        }

        /// <summary>
        /// This class Displays the String
        /// </summary>
        /// <param name="str">Result of all operations</param>
        internal void Display(string str)
        {
            Console.WriteLine(str);
        }
    }
}