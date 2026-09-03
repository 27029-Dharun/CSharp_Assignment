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
    public void HandleCalculatorMenu()
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
                        this.CalculateResult(MathUtils.Add, "addition");
                        break;

                    case MenuOption.Subtract:
                        this.CalculateResult(MathUtils.Subtract, "subtraction");
                        break;

                    case MenuOption.Multiply:
                        this.CalculateResult(MathUtils.Multiply, "multiplication");
                        break;

                    case MenuOption.Division:
                        this.CalculateResult(MathUtils.Divide, "division");
                        break;

                    case MenuOption.Exit:
                        return;
                }
            }
            catch (FormatException e)
            {
                this._view.Print(e.Message);
            }
            catch (DivideByZeroException e)
            {
                this._view.Print(e.Message);
            }

            this._view.PauseAndClear();
        }
    }

    private void CalculateResult<T>(Func<int, int, T> calculate, string option)
    {
        this._view.PrintHeader($"Performing {option}");
        int firstNumber = this._view.GetNumber("Enter the first number: ");
        int secondNumber = this._view.GetNumber("Enter the second number: ");

        this._view.Print($"The result for {option} on {firstNumber} & {secondNumber} is {calculate(firstNumber, secondNumber)}");
    }
}
