using Reflection.DynamicMethodInvoker;

namespace Reflection;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        AssemblyInception assemblyInception = new AssemblyInception();
        DynamicInspector dynamicInspector = new DynamicInspector();
        MethodInvoker methodInvoker = new MethodInvoker();
        DynamicTypeBuilder dynamicTypeBuilder = new DynamicTypeBuilder();
        PluginLoader pluginLoader = new PluginLoader();
        Serializer serializer = new Serializer();

        while (true)
        {
            string mainMenu = $@"
1. Assembly Metadata
2. Object Inspector
3. Method Invoker
4. Dynamic Type Builder
5. Plugin Loader
6. Serialization API
[E]xit
Enter Choice: ";
            Console.Write(mainMenu);
            _ = int.TryParse(Console.ReadLine(), out int userChoice);
            Console.Clear();
            switch (userChoice)
            {
                case 1:
                    assemblyInception.DisplayAssemblyData();
                    break;
                case 2:
                    dynamicInspector.Build();
                    break;
                case 3:
                    methodInvoker.GetDetails();
                    break;
                case 4:
                    dynamicTypeBuilder.Build();
                    break;
                case 5:
                    pluginLoader.Load();
                    break;
                case 6:
                    serializer.PerformOperation();
                    break;
                case 7:
                    Console.Write("\nExiting...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice\n");
                    break;
            }
        }
    }
}