using Collections.IO;

namespace AdvancedFeatures.Tasks;

/// <summary>
/// Contains the usage of var and dynamic keywords.
/// </summary>
internal class VarAndDynamic
{
    /// <summary>
    /// Demonstrates the usage of var keyword.
    /// </summary>
    internal void VarAndDelegateDemonstration()
    {
        // should assign during declaration.
        var input = 10;

        // Uncomment to change type (but then 'var' must be replaced with 'object')
        // input = "Dharun";
        // This won't compile with 'var' because type is fixed at compile time
        ConsoleIO.PrintInfo($"Initial value of the variable {input}, type : {input.GetType()}");

        ConsoleIO.PrintInfo("\nShould assign the value for var during declaration");
        ConsoleIO.PrintInfo("The type can't be changed because the type is fixed at the compile time.\n");

        // Can assign after declaration
        dynamic dynamicVariable;

        dynamicVariable = 10;
        ConsoleIO.PrintInfo($"Initial value of the dynamic variable {dynamicVariable}, type: {dynamicVariable.GetType()}");

        // Can change the datatype of the variable
        dynamicVariable = "ABC";
        ConsoleIO.PrintInfo($"The value of the dynamic variable is changed to {dynamicVariable}, type: {dynamicVariable.GetType()}");

        dynamicVariable = 10.0d;
        ConsoleIO.PrintInfo($"The value of the dynamic variable is changed to {dynamicVariable}, type: {dynamicVariable.GetType()}");

        ConsoleIO.PrintInfo("\nNo need to assign the value for dynamic during declaration");
        ConsoleIO.PrintInfo("The type can be changed because the type is fixed at the run time.\n");
    }
}
