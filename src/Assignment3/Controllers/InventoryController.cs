using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3.Controllers
{
    /// <summary>
    /// Inventory Controller
    /// </summary>
    internal class InventoryController
    {
        private InventoryService _inventoryService = new InventoryService();

        /// <summary>
        /// Add Product operation
        /// </summary>
        internal void AddProduct()
        {
            string name = ConsoleView.GetString("Enter the Product Name: ");
            decimal price = ConsoleView.GetDecimal("Enter the Price of the Product: ");
            int quantity = ConsoleView.GetInteger("Enter the Quantity of the Product: ");

            try
            {
                this._inventoryService.CreateInventoryProduct(name, price, quantity);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// View product
        /// </summary>
        internal void ViewProduct()
        {
            List<Inventory> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Any())
            {
                ConsoleView.PrintInfo("Products in Inventory");
                ConsoleView.PrintInventory(inventories);
            }
            else
            {
                ConsoleView.PrintInfo("Inventort is Empty");
            }
        }
    }
}
