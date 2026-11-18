using Collections.IO;
using Collections.Tasks;

namespace Collections.Controllers;

/// <summary>
/// Coordinates and control the flow between the different tasks.
/// </summary>
public class Controller
{
    private const int EntryCount = 5;

    /// <summary>
    /// Handles task menu and executes the task.
    /// </summary>
    public void HandleTaskMenu()
    {
        string menuPrompt = "1. List operation\n" +
            "2. Stack (Reverse string)\n" +
            "3. Queue operation\n" +
            "4. Dictionary operation\n" +
            "5. Concrete type implementation\n" +
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

                    case TaskOptions.CollectionAbstractions:
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
        ListOperations<string> books = new ListOperations<string>(EntryCount);
        ConsoleIO.PrintHeader("List Task");
        ConsoleIO.PrintInfo("Adding books to list\n");

        for (int i = 0; i < EntryCount; i++)
        {
            string book = ConsoleIO.GetString("Enter book name: ");
            books.Add(book);
        }

        ConsoleIO.PrintInfo("\nChecking a book from list\n");
        string bookToSearch = ConsoleIO.GetString("Enter a book name to remove: ");
        if (books.Contains(bookToSearch))
        {
            ConsoleIO.PrintInfo($"The {bookToSearch} is present in the list.");
        }
        else
        {
            ConsoleIO.PrintInfo($"The {bookToSearch} is not present in the list.");
        }

        ConsoleIO.PrintInfo("\nRemoving a book from list\n");
        string bookToRemove = ConsoleIO.GetString("Enter a book name to remove: ");

        if (books.Remove(bookToRemove))
        {
            ConsoleIO.PrintInfo("Removed book from the list.");
        }
        else
        {
            ConsoleIO.PrintInfo("The book is not present in the list.");
        }

        ConsoleIO.PrintInfo("\nDisplaying all the books\n");

        foreach (var book in books.Items)
        {
            ConsoleIO.PrintInfo(book);
        }
    }

    private void HandleStackOperations()
    {
        ConsoleIO.PrintHeader("Reversing a string\n");

        string input = ConsoleIO.GetName("Enter the name to reverse: ");

        ConsoleIO.PrintInfo($"Entered String: {input}");
        ConsoleIO.PrintInfo($"Reversed string : {StackOperations<string>.ReverseString(input)}");
    }

    private void HandleQueueOperations()
    {
        QueueOperations<string> people = new QueueOperations<string>(EntryCount);

        ConsoleIO.PrintHeader("Queue Task\n" +
            "Adding name to queue\n");

        for (int i = 0; i < EntryCount; i++)
        {
            people.Enqueue(ConsoleIO.GetString("Enter the name: "));
        }

        ConsoleIO.PrintInfo("\nRemoving name from queue\n");
        if (people.HasAny())
        {
            string removedName = people.Dequeue();
            ConsoleIO.PrintInfo($"Removed {removedName} from queue\n");

            ConsoleIO.PrintInfo("\nDisplaying all the names\n");

            foreach (var name in people.Entry)
            {
                ConsoleIO.PrintInfo(name);
            }
        }
        else
        {
            ConsoleIO.PrintInfo("Queue contains no entries.");
        }
    }

    private void HandleDictionaryOperations()
    {
        DictionaryOperations<string, int> studentsRecord = new DictionaryOperations<string, int>(EntryCount);
        ConsoleIO.PrintHeader("Students database");

        ConsoleIO.PrintInfo("\nAdding data to dictionary\n");
        for (int i = 0; i < EntryCount; i++)
        {
            string name = ConsoleIO.GetString("Enter the name of the student: ");
            int grade = ConsoleIO.GetInteger($"Enter the grade of {name}: ");

            if (!studentsRecord.TryAdd(name, grade))
            {
                ConsoleIO.PrintInfo($"Name {name} already exists. Enter another name");
                i--;
            }
            else
            {
                ConsoleIO.PrintInfo("Student added successfully.");
            }
        }

        ConsoleIO.PrintInfo("\nRemoving a student from dictionary\n");
        string studentName = ConsoleIO.GetString("Enter the name of the student: ");
        if (studentsRecord.Remove(studentName))
        {
            ConsoleIO.PrintInfo($"Removed {studentName} from the dictionary");
        }
        else
        {
            ConsoleIO.PrintInfo($"{studentName} not present in the dictionary");
        }

        ConsoleIO.PrintInfo("\nDisplaying all the students\n");
        ConsoleIO.PrintHeader("Students in the record");

        foreach (var student in studentsRecord.Entries)
        {
            ConsoleIO.PrintInfo($"Name: {student.Key}, Grade: {student.Value}");
        }
    }

    private void HandleConcreteTypesOperations()
    {
        List<int> integerList = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int[] integerArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Queue<int> integerQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

        ConsoleIO.PrintInfo($"Sum of element in list: {CollectionAbstractions.SumOfElements(integerList)}");
        ConsoleIO.PrintInfo($"Sum of element in array: {CollectionAbstractions.SumOfElements(integerArray)}");
        ConsoleIO.PrintInfo($"Sum of element in queue: {CollectionAbstractions.SumOfElements(integerQueue)}");

        IReadOnlyDictionary<string, int> dictionary = CollectionAbstractions.GenerateDictionary();
        CollectionAbstractions.PrintDictionary(dictionary);

        ConsoleIO.PrintInfo("Trying to modify the dictionary");
        CollectionAbstractions.TryModifyDictionary(dictionary);
    }
}
