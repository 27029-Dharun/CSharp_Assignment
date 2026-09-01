using Assignment10.Enums;
using Assignment10.Utilities;
using Assignment10.Views;

namespace Assignment10;

/// <summary>
/// Basic calculator application.
/// </summary>
public class BasicCalculator
{
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicCalculator"/> class.
    /// </summary>
    /// <param name="view">Instance of view</param>
    public BasicCalculator(ConsoleView view)
    {
        this._view = view;
    }

    /// <summary>
    /// Calculator entry point
    /// Handle menu and switch between operation
    /// </summary>
    public void HandleMenu()
    {
        while (true)
        {
            try
            {
                MenuOption option = this._view.GetMenu();
                this._view.ClearConsole();
                switch (option)
                {
                    case MenuOption.Add:
                        this.AddInteger();
                        break;

                    case MenuOption.Subtract:
                        this.SubtractInteger();
                        break;

                    case MenuOption.Multiply:
                        this.MultiplyInteger();
                        break;

                    case MenuOption.Division:
                        this.DivideInteger();
                        break;

                    case MenuOption.Exit:
                        return;
                }
            }
            catch (InvalidDataException e)
            {
                this._view.Print(e.Message);
            }
            catch (DivideByZeroException)
            {
                this._view.Print("Can't divide an integer by zero");
            }

            this._view.PauseAndClear();
        }
    }

    private void AddInteger()
    {
        this._view.PrintHeader("Add two integer");
        int num1 = this._view.GetNumber("Enter the first number: ");
        int num2 = this._view.GetNumber("Enter the second number: ");

        this._view.Print($"The result for {num1} + {num2} = {MathUtils.Add(num1, num2)}");
    }

    private void SubtractInteger()
    {
        this._view.PrintHeader("Subtract two integer");
        int num1 = this._view.GetNumber("Enter the first number: ");
        int num2 = this._view.GetNumber("Enter the second number: ");

        this._view.Print($"The result for {num1} - {num2} = {MathUtils.Subtract(num1, num2)}");
    }

    private void MultiplyInteger()
    {
        this._view.PrintHeader("Multiply two integer");
        int num1 = this._view.GetNumber("Enter the first number: ");
        int num2 = this._view.GetNumber("Enter the second number: ");

        this._view.Print($"The result for {num1} * {num2} = {MathUtils.Multiply(num1, num2)}");
    }

    private void DivideInteger()
    {
        this._view.PrintHeader("Divide two integer");
        int num1 = this._view.GetNumber("Enter the first number: ");
        int num2 = this._view.GetNumber("Enter the second number: ");

        if (num2 == 0)
        {
            this._view.Print("Can't divide an integer by zero");
            return;
        }

        this._view.Print($"The result for {num1} / {num2} = {MathUtils.Divide(num1, num2)}");
    }
}
