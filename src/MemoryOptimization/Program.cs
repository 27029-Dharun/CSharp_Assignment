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
                        long memoryUsedBeforeMemoryEater = GC.GetTotalMemory(false);
                        MemoryEater memoryEater = new MemoryEater();
                        memoryEater.Allocate();
                        long memoryUsedAfterMemoryEater = GC.GetTotalMemory(false);

                        Console.WriteLine($"Memory used by original implementation {memoryUsedAfterMemoryEater - memoryUsedBeforeMemoryEater} bytes\n");
                        break;

                    case 2:
                        long memoryUsedBeforeOptimization = GC.GetTotalMemory(false);
                        MemoryOptimization optimizedMemoryUsage1 = new MemoryOptimization();
                        optimizedMemoryUsage1.Allocate();
                        long memoryUsedAfterOptimization = GC.GetTotalMemory(false);

                        Console.WriteLine($"Memory used by optimized version {memoryUsedAfterOptimization - memoryUsedBeforeOptimization} bytes\n");
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