namespace Assignment8.Helpers
{
    internal static class ConsoleHelper
    {
        public static void PrintColoredText(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static string GetString(string prompt)
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            return input;
        }
    }
}
