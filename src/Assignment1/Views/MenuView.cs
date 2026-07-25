namespace Assignment1.View
{
    /// <summary>
    /// Menu Display class
    /// </summary>
    internal class MenuView
    {
        /// <summary>
        /// Menu OPtion display method
        /// </summary>
        /// <returns>Int option for the operation to continue</returns>
        public static int DisplayMenu()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Continue with an Operation");
            Console.WriteLine("1. Add the contact");
            Console.WriteLine("2. View the contact");
            Console.WriteLine("3. Edit the contact");
            Console.WriteLine("4. Delete the contact");
            Console.WriteLine("5. Search contact By Name");
            Console.WriteLine("6. Sort Contact");
            Console.WriteLine("7. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a valid integer option");
            }

            return input;
        }
    }
}
