using System.Reflection;

namespace Reflection;

/// <summary>
/// Inspects the Assembly.
/// </summary>
internal class DynamicObjectInspector
{
    /// <summary>
    /// Performs inspection
    /// </summary>
    public void PerformInspection()
    {
        Student student = new Student();
        this.DisplayProperties(student);

        Console.Write($"\nEnter Property name: ");
        string? propertyName = Console.ReadLine();
        Console.Write($"Enter new value: ");
        string? newValue = Console.ReadLine();

        if (propertyName != null && newValue != null)
        {
            this.UpdateProperty(student, propertyName, newValue);
            this.DisplayProperties(student);
        }
        else
        {
            Console.WriteLine($"\nEnter a valid data");
        }

        ConsoleIO.ClearConsole();
    }

    /// <summary>
    /// Displays the current object details.
    /// </summary>
    /// <param name="obj">Object to be displayed.</param>
    public void DisplayProperties(object obj)
    {
        Type type = obj.GetType();
        foreach (PropertyInfo property in type.GetProperties())
        {
            Console.WriteLine($"{property.Name} : {property.GetValue(obj)}");
        }
    }

    /// <summary>
    /// Updated the object property's values.
    /// </summary>
    /// <param name="obj">Object to be updated.</param>
    /// <param name="propertyName">Property name which needs to be modified.</param>
    /// <param name="newValue">New value for the property.</param>
    public void UpdateProperty(object obj, string propertyName, string newValue)
    {
        PropertyInfo? property = obj.GetType().GetProperty(propertyName);

        if (property != null && property.CanWrite)
        {
            object value = Convert.ChangeType(newValue, property.PropertyType);
            property.SetValue(obj, value);
            Console.WriteLine($"Property updated\n");
        }
        else
        {
            Console.WriteLine("Property not found");
        }
    }
}
