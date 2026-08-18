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

        public void Divide()
        {
            int number1 = this._view.GetInteger("Enter the first number to perform division");
            int number2 = this._view.GetInteger("");
        }
    }
}
