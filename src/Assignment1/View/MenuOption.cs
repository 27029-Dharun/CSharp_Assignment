using Assignments1;

namespace Assignment1.Ui
{
    /// <summary>
    /// Menu Display class
    /// </summary>
    internal class MenuOption
    {
        /// <summary>
        /// Menu OPtion display method
        /// </summary>
        public void DisplayMenu()
        {
            string? input;
            ConsoleOperations consoleOperations = new ConsoleOperations();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter the number to Continue with an Operation");
                Console.WriteLine("1. Add the contact");
                Console.WriteLine("2. View the contact");
                Console.WriteLine("3. Edit the contact");
                Console.WriteLine("4. Delete the contact");
                Console.WriteLine("5. Search contact By Name");
                Console.WriteLine("6. Sort Contact");
                Console.WriteLine("Type [exit] To Exit");

                input = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                switch (input)
                {
                    case "1":
                        consoleOperations.GetContact();
                        break;

                    case "2":
                        consoleOperations.ViewContact();
                        break;

                    case "3":
                        consoleOperations.EditContact();
                        break;

                    case "4":
                        consoleOperations.DeleteContact();
                        break;

                    case "5":
                        consoleOperations.SearchContacts();
                        break;

                    case "6":
                        consoleOperations.SortContact();
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
    }
}
