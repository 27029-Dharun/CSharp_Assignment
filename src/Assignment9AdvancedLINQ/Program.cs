using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Tasks;
using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ;

/// <summary>
/// Program class for starting the operation
/// </summary>
public class Program
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
    /// </summary>
    public static void Main()
    {
        Database database = new Database();

        BasicLinqQuery basicLinqQuery = new BasicLinqQuery(database);
        ComplexLinqQuery complexLinqQuery = new ComplexLinqQuery(database);
        ArrayOperations task3 = new ArrayOperations();
        QueryOptimization task4 = new QueryOptimization(database);
        MethodChaining task5 = new MethodChaining(database);

        database.InitializeData();

        while (true)
        {
            MenuOption option = ConsoleIO.GetEnumValue<MenuOption>("Select the option to continue: ");

            switch (option)
            {
                case MenuOption.Task1:
                    basicLinqQuery.GetAveragePrice();
                    break;

                case MenuOption.Task2:
                    complexLinqQuery.ComplexLinqQueries();
                    break;

                case MenuOption.Task3:
                    task3.HandleArrayOperations();
                    break;

                case MenuOption.Task4:
                    task4.GetBooksCategory();
                    break;

                case MenuOption.Task5:
                    task5.SortList();
                    break;

                case MenuOption.Exit:
                    return;

                default:
                    ConsoleIO.PrintInfo("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }
}