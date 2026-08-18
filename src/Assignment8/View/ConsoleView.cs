
namespace Assignment8.View
{
    /// <summary>
    /// Contains all the view 
    /// </summary>
    public class ConsoleView
    {
        public void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintError(string message)
        {
            PrintColoredText(message, ConsoleColor.Red);
        }

        public void PrintSuccess(string message)
        {
            PrintColoredText(message, ConsoleColor.Green);
        }

        public void PrintWarning(string message)
        {
            PrintColoredText(message, ConsoleColor.Yellow);
        }

        internal int GetInteger()
        {

        }
    }
}
