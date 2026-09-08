namespace Assignment12;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        MemoryEater memoryEater = new MemoryEater();
        while (true)
        {
            string mainMenu = $"1. Memory Eater Task\n" +
                "2. Memory Optimization 1\n" +
                "3. Memory Optimization 2\n" +
                "4. Exit\n" +
                "Enter Choice: ";

            Console.Write(mainMenu);
            int.TryParse(Console.ReadLine(), out int userChoice);

            switch (userChoice)
            {
                case 1:
                    memoryEater.Allocate();
                    break;

                case 2:
                    using (OptimizedMemoryUsage1 optimizedMemoryUsage1 = new OptimizedMemoryUsage1())
                    {
                        optimizedMemoryUsage1.Allocate();
                    }

                    break;

                case 3:
                    OptimizedMemoryUsage2 optimizedMemoryUsage = new OptimizedMemoryUsage2();
                    optimizedMemoryUsage.Allocate();

                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}