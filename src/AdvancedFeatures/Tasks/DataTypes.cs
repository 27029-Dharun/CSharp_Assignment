namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the usage of var and dynamic keywords.
/// </summary>
internal class DataTypes
{
    /// <summary>
    /// Demonstrates the usage of var keyword.
    /// </summary>
    internal void VarAndDelegateDemonstration()
    {
        // should assign during declaration.
        var input = 10;

        // Uncomment to change type (but then 'var' must be replaced with 'object')
        // input = "Dharun"; // This won't compile with 'var' because type is fixed at compile time
        Console.WriteLine($"Type of the var variable: {input.GetType()}");

        // Can assign after declaration
        dynamic delegateVariable;

        delegateVariable = 10;
        Console.WriteLine(delegateVariable.GetType());

        // Can change the datatype of the variable
        delegateVariable = "ABC";
        Console.WriteLine(delegateVariable.GetType());

        delegateVariable = 10.0d;
        Console.WriteLine(delegateVariable.GetType());
    }
}
