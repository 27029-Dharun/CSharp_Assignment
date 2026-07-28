using Assignment3.Controllers;
using Assignment3.Models;
using Assignment3.Utility;

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
            IOUtility.PrintInfo("Welcome to Inventory Management Application");
            int option;
            do
            {
                option = IOUtility.GetInteger("1. Add a Product\n2. View all product\n3. Editing Producr\n4. Delete Product\n5. Exit\n");
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
                        return;

                    default:
                        IOUtility.PrintInfo("Enter an option in range 1 - 5");
                        break;
                }
            }
            while (option != (int)InventoryOperation.Exit);
        }
    }
}
