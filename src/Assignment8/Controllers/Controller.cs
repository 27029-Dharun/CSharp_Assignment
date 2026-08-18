using Assignment8.Enums;
using Assignment8.View;

namespace Assignment8.Controllers
{
    public class Controller
    {
        private ConsoleView _view;

        public Controller(ConsoleView view)
        {
            this._view = view;
        }

        public void HandleMenu()
        {
            MenuOption option = this._view.GetMenuOption();

            try
            {
                switch (option)
                {
                    case MenuOption.Divide:
                        this.HandleDivideInteger();
                        break;

                    case MenuOption.Array:
                        this.HandleArray();
                        break;

                    default:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void HandleDivideInteger()
        {
            int dividend = this._view.GetInteger("Enter the dividend to perform division: ");
            int divisor = this._view.GetInteger("Enter the divisor to perform division: ");

            try
            {
                decimal quotient = dividend / divisor;
            }
            catch (DivideByZeroException)
            {
                this._view.PrintWarning("Can't divide a number with zero, Please enter a valid divisor");
            }
            finally
            {
                this._view.PrintInfo("Finally block execution");
            }
        }

        public void HandleArray()
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int index = this._view.GetInteger("Enter the index to get the value from the array: ");
            try
            {
                this._view.PrintInfo($"The element in the array at index[{index}] is {array[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Invalid index, please enter the index in range 0-9");
            }
        }
    }
}
