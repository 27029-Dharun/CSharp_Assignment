namespace ValueAndReferenceTypes;

/// <summary>
/// Program class which acts as the entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public static void Main()
    {
        // Task 1
        PersonStruct personStruct = default;
        personStruct.Name = "Dharun";
        personStruct.Age = 20;

        Person person = new Person()
        {
            Name = "Dharun",
            Age = 20,
        };

        Console.WriteLine("======= Value And Reference type =======\n\n" +
            $"The value of value type variable before incrementing: {personStruct.Age}\n" +
            $"The value of reference type variable before incrementing: {person.Age}\n");

        Increment(person, personStruct);
        Console.WriteLine($"The value of value type variable after incrementing: {personStruct.Age}\n" +
            $"The value of reference type variable after incrementing: {person.Age}\n");

        // Task 2
        Console.WriteLine("======= Working with the Stack and the Heap =======\n\n" +
            "Creating memory for reference type\n");
        long startMemory = GC.GetAllocatedBytesForCurrentThread();

        CreateArray();

        long endMemory = GC.GetAllocatedBytesForCurrentThread();
        Console.WriteLine($"Heap memory is increased by {endMemory - startMemory} bytes - for creating a reference type\n");

        // Creating value type variables are performing calculations.
        Console.WriteLine("Calculation with large number of local variables\n");

        GC.Collect();
        startMemory = GC.GetAllocatedBytesForCurrentThread();

        CalculateUsingLocalVariables();

        endMemory = GC.GetAllocatedBytesForCurrentThread();

        Console.WriteLine($"Heap memory increased {endMemory - startMemory} bytes - for creating a value type\n" +
            "The heap memory is not increased because the variables are stored in the stack\n");

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static decimal CalculateUsingLocalVariables()
    {
        decimal number1 = 10;
        decimal number2 = 20;
        decimal number3 = 30;
        decimal number4 = 40;
        decimal number5 = 50;
        decimal number6 = 60;
        decimal number7 = 70;

        return number1 + number2 + number3 + number4 + number5 + number6 + number7;
    }

    private static void CreateArray()
    {
        // create a array with all values as zero.
        int[] array = new int[1_00_000];
    }

    private static void Increment(Person person, PersonStruct personStruct)
    {
        person.Age++;
        personStruct.Age++;
    }
}