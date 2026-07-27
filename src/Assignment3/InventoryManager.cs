using Assignment3.Controllers;
using Assignment3.Models;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Runs the Inventory
    /// </summary>
    internal class InventoryManager
    {
        private InventoryController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// </summary>
        /// <param name="controller">Controller object</param>
        public InventoryManager(InventoryController controller)
        {
            this._controller = controller;
        }

        /// <summary>
        /// Displays the operation and gets input
        /// </summary>
        public void Run()
        {
            ConsoleView.PrintInfo("Welcome to Inventory Management Application");
            int option;
            do
            {
                option = ConsoleView.GetInteger("1. Add a Product\n2. View all product\n3. Editing Producr\n4. Delete Product\n5. Exit\n");
                switch (option)
                {
                    case (int)Enums.InventoryOperation.Add:
                        this._controller.AddProduct();
                        break;

                    case (int)Enums.InventoryOperation.View:
                        this._controller.ViewProduct();
                        break;

                    case (int)Enums.InventoryOperation.Update:
                        break;

                    case (int)Enums.InventoryOperation.Delete:
                        break;

                    case (int)Enums.InventoryOperation.Exit:
                        break;

                    default:
                        ConsoleView.PrintInfo("Enter an option in range 1 - 5");
                        break;
                }
            }
            while (option != (int)Enums.InventoryOperation.Exit);
        }
    }
}
