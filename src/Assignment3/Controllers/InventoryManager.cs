using Assignment3.Models;
using Assignment3.View;

namespace Assignment3.Controllers
{
    /// <summary>
    /// Runs the Inventory
    /// </summary>
    internal class InventoryManager
    {
        private InventoryController _controller;
        private ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// </summary>
        /// <param name="controller">Controller object</param>
        /// <param name="view">View Object</param>
        public InventoryManager(InventoryController controller, ConsoleView view)
        {
            this._controller = controller;
            this._view = view;
        }

        /// <summary>
        /// Displays the operation and gets input
        /// </summary>
        public void Run()
        {
            this._view.PrintInfo("Welcome to Inventory Management Application");
            bool option = true;
            do
            {
                try
                {
                    option = this.InventoryOptions();
                }
                catch (KeyNotFoundException ex)
                {
                    this._view.PrintInfo(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    this._view.PrintInfo(ex.Message);
                }
                catch (FormatException ex)
                {
                    this._view.PrintInfo(ex.Message);
                }
                catch (Exception ex)
                {
                    this._view.PrintInfo(ex.Message);
                }
            }
            while (option != false);
        }

        private bool InventoryOptions()
        {
            int option = this._view.GetInteger("1. Add a Product\n2. View all product\n3. Edit Product\n4. Delete Product\n5. Exit\n");
            Console.Clear();
            switch (option)
            {
                case (int)InventoryOperation.Add:
                    this._controller.AddProduct();
                    break;

                case (int)InventoryOperation.View:
                    this._controller.ViewProduct();
                    break;

                case (int)InventoryOperation.Update:
                    this._controller.EditProduct();
                    break;

                case (int)InventoryOperation.Delete:
                    this._controller.DeleteProduct();
                    break;

                case (int)InventoryOperation.Exit:
                    return false;

                default:
                    this._view.PrintInfo("Enter an option in range 1 - 5");
                    break;
            }

            return true;
        }
    }
}
