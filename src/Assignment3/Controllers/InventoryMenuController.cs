using Assignment3.Models;
using Assignment3.View;

namespace Assignment3.Controllers
{
    /// <summary>
    /// Acts as a entry point of the application.
    /// </summary>
    internal class InventoryMenuController
    {
        private readonly InventoryController _controller;
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryMenuController"/> class.
        /// </summary>
        /// <param name="controller">Instance of controller</param>
        /// <param name="view">Instance of view that performs all the console operation.</param>
        public InventoryMenuController(InventoryController controller, ConsoleView view)
        {
            this._controller = controller;
            this._view = view;
        }

        /// <summary>
        /// Displays the menu option and gets a option as input continuously until the user exits.
        /// </summary>
        public void Starter()
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
                catch (InvalidOperationException ex)
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

            this._view.PrintInfo("Enter a Key to Exit...");
            this._view.ReadKey();
        }

        private bool InventoryOptions()
        {
            this._view.PrintEmptyLine();
            int option = this._view.GetInteger("1. Add a product\n2. View all product\n3. Edit Product\n4. Delete Product\n5. Search Product\n6. Sort Products\n7. Exit\nChoose an operation to continue: ");
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

                case (int)InventoryOperation.Search:
                    this._controller.SearchProduct();
                    break;

                case (int)InventoryOperation.Sort:
                    this._controller.SortProduct();
                    break;

                case (int)InventoryOperation.Exit:
                    return false;

                default:
                    this._view.PrintInfo("Enter an option in range 1 - 7");
                    break;
            }

            return true;
        }
    }
}
