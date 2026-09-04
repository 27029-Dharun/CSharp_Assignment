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
        Console.WriteLine("=======");
        using (FileWriter fileWriter = new FileWriter(path))
        {
            fileWriter.Write("Hello world");
        }

        string content = File.ReadAllText(path);
        Console.WriteLine(content);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}