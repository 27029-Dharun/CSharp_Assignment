using Collections.IO;
using Collections.Tasks;

namespace Collections.Controllers;

/// <summary>
/// Coordinates and control the flow between the different tasks.
/// </summary>
public class Controller
{
    /// <summary>
    /// Handles task menu and executes the task.
    /// </summary>
    public void HandleTaskMenu()
    {
        string menuPrompt = "1. List operation\n" +
            "2. Stack (Reverse string)\n" +
            "3. Queue operation\n" +
            "4. Dictionary operation\n" +
            "5. Concrete type implementation" +
            "6. Exit\n" +
            "Enter an option to continue: ";

        while (true)
        {
            try
            {
                TaskOptions option = ConsoleIO.GetEnumOption<TaskOptions>(menuPrompt);

                switch (option)
                {
                    case TaskOptions.List:
                        this.HandleListOperations();
                        break;

                    case TaskOptions.Stack:
                        this.HandleStackOperations();
                        break;

                    case TaskOptions.Queue:
                        this.HandleQueueOperations();
                        break;

                    case TaskOptions.Dictionary:
                        this.HandleDictionaryOperations();
                        break;

                    case TaskOptions.ConcreteTypes:
                        this.HandleConcreteTypesOperations();
                        break;

                    case TaskOptions.Exit:
                        return;
                }
            }
            catch (Exception e)
            {
                ConsoleIO.PrintInfo(e.Message);
            }

            ConsoleIO.PauseAndClear();
        }
    }

    private void HandleListOperations()
    {
        ListOperations<string> list = new ListOperations<string>();
        ConsoleIO.PrintHeader("List Task");
        ConsoleIO.PrintInfo("Adding books to list\n");

        string[] arr = new string[5];
        for (int i = 0; i < 5; i++)
        {
            arr[i] = ConsoleIO.GetString("Enter book name: ");
        }

        list.AddBooks(arr);

        ConsoleIO.PrintInfo("\nRemoving a book from list\n");
        string nameToDelete = ConsoleIO.GetString("Enter a book name to remove: ");
        list.DeleteBook(nameToDelete);

        ConsoleIO.PrintInfo("\nDisplaying all the books\n");
        list.DisplayBooks();
    }

    private void HandleStackOperations()
    {
        StackOperations<char> stack = new StackOperations<char>();
        ConsoleIO.PrintHeader("Reversing a string\n");

        string input = ConsoleIO.GetName("Enter the name to reverse: ");
        List<char> charArray = new List<char>();
        foreach (char character in input)
        {
            charArray.Add(character);
        }

        stack.AddCharacter(charArray);
        ConsoleIO.PrintInfo($"Entered String: {input}");

        List<char> reversed = stack.ReverseCharacter();
        ConsoleIO.PrintInfo($"Reversed string : {string.Join(string.Empty, reversed)}");
    }

    private void HandleQueueOperations()
    {
        QueueOperations<string> queue = new QueueOperations<string>();
        ConsoleIO.PrintHeader("Queue Task");
        ConsoleIO.PrintInfo("Adding name to queue\n");

        string[] names = new string[5];
        for (int i = 0; i < 5; i++)
        {
            names[i] = ConsoleIO.GetString("Enter the name: ");
        }

        queue.AddNames(names);

        ConsoleIO.PrintInfo("\nRemoving name from queue\n");
        if (!queue.HasAny())
        {
            Console.WriteLine("Queue contains no entries.");
        }

        string removedName = queue.RemoveName();
        Console.WriteLine($"Removed {removedName} from queue");

        ConsoleIO.PrintInfo("\nDisplaying all the names\n");
        queue.DisplayNames();
    }

    private void HandleDictionaryOperations()
    {
        DictionaryOperations<string, int> studentsRecord = new DictionaryOperations<string, int>();
        ConsoleIO.PrintHeader("Students database");
        ConsoleIO.PrintInfo("\nAdding data to dictionary\n");

        string[] names = new string[5];
        int[] grade = new int[5];
        for (int i = 0; i < 5; i++)
        {
            names[i] = ConsoleIO.GetString("Enter the name of the student: ");

            if (studentsRecord.ContainsKey(names[i]))
            {
                Console.WriteLine($"Name {names[i]} already exists.");
                i--;
                continue;
            }

            grade[i] = ConsoleIO.GetInteger($"Enter the grade of {names[i]}: ");
        }

        studentsRecord.CreateStudentData(names, grade);

        ConsoleIO.PrintInfo("\nRemoving a student from dictionary\n");
        string studentName = ConsoleIO.GetString("Enter the name of the student: ");
        studentsRecord.DeleteStudent(studentName);

        ConsoleIO.PrintInfo("\nDisplaying all the students\n");
        studentsRecord.DisplayStudent();
    }

    private void HandleConcreteTypesOperations()
    {
        ConcreteTypes concreteTypes = new ConcreteTypes();

        List<int> integerList = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] integerArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Queue<int> integerQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

        Console.WriteLine($"Sum of element in list: {concreteTypes.SumOfElements(integerList)}");
        Console.WriteLine($"Sum of element in array: {concreteTypes.SumOfElements(integerArray)}");
        Console.WriteLine($"Sum of element in queue: {concreteTypes.SumOfElements(integerQueue)}");

        IReadOnlyDictionary<string, int> dictionary = concreteTypes.GenerateDictionary();
        concreteTypes.PrintDictionary(dictionary);
    }
}
