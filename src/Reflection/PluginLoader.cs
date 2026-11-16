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
        string path = "IGreetingsPlugin.dll";

        Assembly assembly = Assembly.Load(Path.GetFullPath(path));
        foreach (Type type in assembly.GetTypes())
        {
            if (type != null && type.IsClass && !type.IsAbstract && typeof(IGreetings).IsAssignableFrom(type))
            {
                IGreetings? plugin = Activator.CreateInstance(type) as IGreetings;
                plugin?.Greet();
            }
        }
    }
}
