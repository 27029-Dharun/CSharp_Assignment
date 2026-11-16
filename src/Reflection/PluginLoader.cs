using System.Reflection;

namespace Reflection;
using IGreetingsPlugin;

/// <summary>
/// Loads the greeting plugin.
/// </summary>
internal class PluginLoader
{
    /// <summary>
    /// Performs plugin loading operation.
    /// </summary>
    public void Load()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "GreetingsPlugin.dll");

        if (!File.Exists(path))
        {
            Console.WriteLine("File Not Found");
        }

        Assembly assembly = Assembly.LoadFrom(path);
        foreach (Type type in assembly.GetTypes())
        {
            if (type != null && type.IsClass && !type.IsAbstract && typeof(IGreetings).IsAssignableFrom(type))
            {
                IGreetings? plugin = Activator.CreateInstance(type) as IGreetings;
                plugin?.Greet();
            }
        }

        ConsoleIO.ClearConsole();
    }
}
