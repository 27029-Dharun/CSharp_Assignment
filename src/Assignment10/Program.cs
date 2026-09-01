using Assignment10;
using Assignment10.Views;

namespace Assignments
{
    /// <summary>
    /// Program class which acts as the start of the program and calls the respective tasks.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of the program.
        /// </summary>
        public static void Main()
        {
            ConsoleView view = new ConsoleView();
            BasicCalculator calculator = new BasicCalculator(view);

            try
            {
                calculator.HandleMenu();
            }
            catch (Exception e)
            {
                view.Print(e.Message);
            }
        }
    }
}