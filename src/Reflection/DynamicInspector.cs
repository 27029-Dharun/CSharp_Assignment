using System.Reflection;
using System.Reflection.Emit;

namespace Reflection;

/// <summary>
/// Inspects the Assembly.
/// </summary>
internal class DynamicInspector
{
    /// <summary>
    /// Builds the assembly dynamically.
    /// </summary>
    internal void Build()
    {
        AssemblyName assembly = new AssemblyName("DynamicAssembly");

        AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        System.Reflection.Emit.TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", TypeAttributes.Public);
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
