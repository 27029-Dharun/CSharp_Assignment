namespace Assignment3.Models
{
    /// <summary>
    /// Inventory Data
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
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
        /// Id of the product
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets or sets product name
        /// </summary>
        /// <value>
        /// Name of the product
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// gets or sets product price
        /// </summary>
        /// <value>
        /// Price of the product
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// gets or sets product quantity
        /// </summary>
        /// <value>
        /// Quantity of the product
        /// </value>
        public int Quantity { get; set; }
    }
}
