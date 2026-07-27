using Assignment3.Controllers;
using Assignment3.Models;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Runs the Inventory
    /// </summary>
    internal class RunInventory
    {
        /// <summary>
        /// Displays the operation and gets input
        /// </summary>
        public void Run()
        {
            InventoryController controller = new InventoryController();
            ConsoleView.PrintInfo("Welcome to Inventory Management Application");
            int option;
            do
            {
                option = ConsoleView.GetInteger("1. Add a Product\n2. View all product\n3. Editing Producr\n4. Delete Product\n5. Exit\n");
                switch (option)
                {
                    case (int)Enums.InventoryOperation.Add:
                        controller.AddProduct();
                        break;

                    case (int)Enums.InventoryOperation.View:
                        controller.ViewProduct();
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
