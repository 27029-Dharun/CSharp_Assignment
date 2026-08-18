namespace Assignment8.Helpers
{
    internal static class ConsoleHelper
    {
        private const int Tries = 3;

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

        public static T GetEnumValue<T>(string message)
    where T : struct, Enum
        {
            int tries = Tries;
            Console.WriteLine($"\n{message}");
            foreach (var value in Enum.GetValues<T>())
            {
                Console.WriteLine($"{Convert.ToInt32(value)}. {value}");
            }

            string input = Console.ReadLine() ?? string.Empty;
            int integer;
            while (!int.TryParse(input, out integer) || !Enum.IsDefined(typeof(T), integer))
            {
                if (tries == 1)
                {
                    throw new InvalidDataException("No attempt left, Please try again." + Environment.NewLine);
                }

                Console.WriteLine($"Tries left: {--tries}, Enter the valid integer");
                Console.WriteLine($"{message}");
                input = Console.ReadLine() ?? string.Empty;
            }

            return (T)Enum.ToObject(typeof(T), integer);
        }

        public static string GetValidatedInput(string prompt, bool optional, Func<string, bool> isValidField, string errorMessage)
        {
            int tries = Tries;
            string input = GetString(prompt);
            if (optional && string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            while (!isValidField(input))
            {
                if (tries == 1)
                {
                    throw new InvalidDataException("No attempt left, Please try again." + Environment.NewLine);
                }

                Console.WriteLine(errorMessage);
                Console.WriteLine($"Tries left: {--tries}\n");
                input = GetString(prompt);
            }

            return input;
        }
    }
}
