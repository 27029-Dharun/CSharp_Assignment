namespace Assignment12;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        while (true)
        {
            string mainMenu = $"1. Memory Eater Task(Allocates memory until the OutOfMemoryException)\n" +
                "2. Memory Optimization\n" +
                "3. Exit\n" +
                "Enter Choice: ";

            Console.Write(mainMenu);
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        MemoryEater memoryEater = new MemoryEater();
                        memoryEater.Allocate();
                        break;

                    case 2:
                        using (MemoryOptimization1 optimizedMemoryUsage1 = new MemoryOptimization1())
                        {
                            optimizedMemoryUsage1.Allocate();
                        }

                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}