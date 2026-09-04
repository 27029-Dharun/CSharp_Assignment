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
        Console.WriteLine(personStruct.Name);
        Console.WriteLine(personStruct.Age);
        personStruct.Name = "Dharun";
        personStruct.Age = 20;

        Person person = new Person()
        {
            Name = "Dharun",
            Age = 20,
        };

        Console.WriteLine("=======Value And Reference type=======" + Environment.NewLine);
        Console.WriteLine($"The value of value type variable before incrementing: {personStruct.Age}");
        Console.WriteLine($"The value of reference type variable before incrementing: {person.Age}" + Environment.NewLine);

        Increment(person, personStruct);
        Console.WriteLine($"The value of value type variable after incrementing: {personStruct.Age}");
        Console.WriteLine($"The value of reference type variable after incrementing: {person.Age}" + Environment.NewLine);

        // Task 2
        Console.WriteLine("=======Working with the Stack and the Heap=======" + Environment.NewLine);
        Console.WriteLine("Creating memory for reference type");
        CreateArray();
        Console.WriteLine("Heap memory is increased" + Environment.NewLine);

        Console.WriteLine("Calculation with large number of local variables");
        CalculateUsingLocalVariables();

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static void CalculateUsingLocalVariables()
    {
        int number1 = 10;
        int number2 = 20;
        int number3 = 30;
        int number4 = 40;
        int number5 = 50;
        int number6 = 60;
        int number7 = 70;
        Console.WriteLine($"Sum: {number1 + number2 + number3 + number4 + number5 + number6 + number7}");
    }

    private static void CreateArray()
    {
        // create a array with all values as zero.
        int[] array = new int[100000];
    }

    private static void Increment(Person person, PersonStruct personStruct)
    {
        person.Age++;
        personStruct.Age++;
    }
}