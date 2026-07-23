namespace Assignment2.Views
{
    /// <summary>
    /// THis class contains all the console operations
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// This method prints info
        /// </summary>
        /// <param name="v">String to be printed</param>
        internal static void PrintInfo(string v)
        {
            Console.WriteLine(v);
        }

        /// <summary>
        /// Get Task to Perform
        /// </summary>
        /// <returns>A task presented by int</returns>
        internal int GetTask()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Continue with a Task");
            Console.WriteLine("1. Shape Hierarchy");
            Console.WriteLine("2. Employee Hierarchy");
            Console.WriteLine("3. Banking System");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return input;
        }
    }
}
