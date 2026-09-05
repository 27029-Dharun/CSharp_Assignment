namespace IDisposableDemo;

/// <summary>
/// Program class which acts as the entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Contains program for using IDisposable.
    /// </summary>
    public static void Main()
    {
        string path = "file.txt";
        Console.WriteLine("======= File Handling =======");
        try
        {
            using (FileWriter fileWriter = new FileWriter(path))
            {
                fileWriter.Write("IDisposable interface.");
                fileWriter.Write("IDisposable is an interface that helps us to release unmanaged resources like database collections, file handlers and opened network connections.");
                fileWriter.Write("It contains a method Dispose that releases the resources when called.");
            } // fileWriter.Dispose() is called automatically

            using (FileReader fileReader = new FileReader(path))
            {
                Console.WriteLine("      Contents in file");
                Console.WriteLine(fileReader.ReadFile());
            } // fileReader.Dispose() is called automatically
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}