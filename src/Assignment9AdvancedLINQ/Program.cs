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
        ConsoleView view = new ConsoleView();
        Database database = new Database();

        BasicLinqQuery basicLinqQuery = new BasicLinqQuery(database, view);
        ComplexLinqQuery complexLinqQuery = new ComplexLinqQuery(database, view);
        ArrayOperations task3 = new ArrayOperations(database, view);
        QueryOptimization task4 = new QueryOptimization(database, view);
        QueryBuilderUsage task5 = new QueryBuilderUsage(database, view);

        database.InitializeData();

        while (true)
        {
            MenuOption option = view.GetEnumValue<MenuOption>("Select the option to continue: ");

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
                    view.PrintInfo("Enter a valid option");
                    break;
            }

            view.PauseAndClear();
        }
    }
}