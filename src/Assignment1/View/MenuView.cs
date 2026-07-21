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
        public string? DisplayMenu()
        {
            string? input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Continue with an Operation");
            Console.WriteLine("1. Add the contact");
            Console.WriteLine("2. View the contact");
            Console.WriteLine("3. Edit the contact");
            Console.WriteLine("4. Delete the contact");
            Console.WriteLine("5. Search contact By Name");
            Console.WriteLine("6. Sort Contact");
            Console.WriteLine("Type [exit] To Exit");

            input = Console.ReadLine();
            return input;
        }
    }
}
