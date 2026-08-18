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
            int option = this._view.GetMenuOption();

            try
            {
                switch (option)
                {
                    case 1:
                        this.Task1();
                        break;

                    case 2:
                        this.Task2();
                        break;

                    case 3:
                        this.Task3();
                        break;

                    case 4:
                        this.Task4();
                        break;

                    case 5:
                        this.Task5();
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

        public void Task1()
        {
            int dividend = 10;
            int divisor = 5;

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

        public void Task2()
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            try
            {
                for (int i = 0; i <= array.Length; i++)
                {
                    this._view.PrintInfo($"The element in the array at index[{i}] is {array[i]}");
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Invalid index, please enter the index in range 0-9");
            }
        }

        public void Task3()
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int index = this._view.GetInteger("Enter the index to get the value from the array: ");

            try
            {
                this._view.PrintInfo($"The element in the array at index {index} is {array[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Invalid index, please enter the index in range 0-9");
            }

            throw new Exception("Unhandled exception thrown");
        }

        private void Task5()
        {

        }

        private void Task4()
        {
            throw new NotImplementedException();
        }

    }
}
