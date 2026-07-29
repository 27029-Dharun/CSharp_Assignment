namespace InventoryManager.Controllers
{
    /// <summary>
    /// Controller Interface
    /// </summary>
    internal interface IController
    {
        /// <summary>
        /// Gets the product Details and adds a product
        /// </summary>
        void AddProduct();

        /// <summary>
        /// Delete product controller gets the index and delete the product
        /// </summary>
        void DeleteProduct();

        /// <summary>
        /// Displays all the product in inventory
        /// </summary>
        void ViewProduct();

        /// <summary>
        /// Edits the product from the inventory
        /// </summary>
        void EditProduct();

        /// <summary>
        /// Search the product in inventory
        /// </summary>
        void SearchProduct();
    }
}
