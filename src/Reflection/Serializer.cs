using System.Reflection.Emit;

namespace Reflection;

/// <summary>
/// Serialize the student data dynamically.
/// </summary>
public class Serializer
{
    /// <summary>
    /// Uses emit operation in reflection to generate dynamic method.
    /// </summary>
    public void PerformOperation()
    {
        Student student = new Student();
        Console.WriteLine($"{this.Serialize(student)}");
        DynamicMethod method = new DynamicMethod("Hello!", typeof(void), Type.EmptyTypes);
        ILGenerator il = method.GetILGenerator();
        il.Emit(OpCodes.Ldstr, "Serialization using Reflection.emit");
        il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }));
        il.Emit(OpCodes.Ret);

        Action display = (Action)method.CreateDelegate(typeof(Action));
        display();
    }

    /// <summary>
    /// Performs serializing operation.
    /// </summary>
    /// <param name="student">Object of the student.</param>
    /// <returns>Returns the serialized string.</returns>
    public string Serialize(Student student)
    {
        Type type = student.GetType();
        string result = string.Empty;
        foreach (var property in type.GetProperties())
        {
            result += $"{property.Name} = {property.GetValue(student)}, ";
        }

        return result;
    }
}
