using System.Reflection;

namespace Reflection.DynamicMethodInvoker;

/// <summary>
/// Created and dynamically invokes method.
/// </summary>
internal class MethodInvoker
{
    /// <summary>
    /// Retrieves method detail to invoke it.
    /// </summary>
    public void GetDetails()
    {
        Calculator calculator = new Calculator();

        Console.Write($"Enter method name(Add/Subtract/Multiplication/Division): ");
        string? methodName = Console.ReadLine();

        if (methodName != null)
        {
            this.InvokeMethod(calculator, methodName);
        }
        else
        {
            Console.WriteLine($"Method not found");
        }

        ConsoleIO.ClearConsole();
    }

    /// <summary>
    /// Performs invoking of the method.
    /// </summary>
    /// <param name="obj">Object to be invoked.</param>
    /// <param name="methodName">Name of the method to be invoked.</param>
    public void InvokeMethod(object obj, string methodName)
    {
        Type type = obj.GetType();
        MethodInfo? method = type.GetMethod(methodName);
        if (method != null)
        {
            method.Invoke(obj, null);
        }
        else
        {
            Console.WriteLine($"Method not found");
        }
    }
}
