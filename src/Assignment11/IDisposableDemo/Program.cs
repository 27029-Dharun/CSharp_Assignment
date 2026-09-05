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
                fileWriter.Write("Hello World");
            } // fileWriter.Dispose() is called automatically

            using (FileReader fileReader = new FileReader(path))
            {
                Console.WriteLine("Contents in file");
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