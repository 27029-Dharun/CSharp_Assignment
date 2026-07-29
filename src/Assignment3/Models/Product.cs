namespace InventoryManager.Models
{
    /// <summary>
    /// Inventory Data
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="name">Product Name</param>
        /// <param name="price">Product price</param>
        /// <param name="quantity">Product Quantity</param>
        /// Used constructor because all are necessary to create a inventory object
        public Product(int id, string name, decimal price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets product Id
        /// </summary>
        /// <value>
        /// Id of the Product
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets or sets product Name
        /// </summary>
        /// <value>
        /// Name of the Product
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// gets or sets Product Price
        /// </summary>
        /// <value>
        /// Price of the Product
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// gets or sets Product Quantity
        /// </summary>
        /// <value>
        /// Quantity of the Product
        /// </value>
        public int Quantity { get; set; }
    }
}
