using System.Reflection;
using System.Reflection.Emit;

namespace Reflection;

/// <summary>
/// Contains the operations to dynamically build operations.
/// </summary>
public class DynamicTypeBuilder
{
    /// <summary>
    /// Dynamically builds assembly, module and type and displays the value to user.
    /// </summary>
    public void Build()
    {
        AssemblyName assembly = new AssemblyName("DynamicAssembly");

        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);
        typeBuilder.DefineField("DynamicField", typeof(string), FieldAttributes.Public);

        Type? dynamicType = typeBuilder.CreateType();
        if (dynamicType is null)
        {
            return;
        }

        object? newObject = Activator.CreateInstance(dynamicType);
        FieldInfo? field = dynamicType.GetField("DynamicField");
        if (field != null)
        {
            field.SetValue(newObject, "Hello World");
            Console.WriteLine(field.GetValue(newObject));
        }

        ConsoleIO.ClearConsole();
    }
}