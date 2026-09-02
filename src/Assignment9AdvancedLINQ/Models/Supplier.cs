namespace Assignment9AdvancedLINQ.Models
{
    /// <summary>
    /// Represents the supplier
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the supplier</param>
        /// <param name="supplierName">Name of the supplier</param>
        /// <param name="productId">Product reference indicating the product supplied by the supplier.</param>
        public Supplier(string id, string supplierName, string productId)
        {
            this.SupplierId = id;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the supplier
        /// </summary>
        /// <value>The unique identifier of the supplier</value>
        public string SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier
        /// </summary>
        /// <value>The name of the supplier</value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        /// <value>The Product supplied by the supplier</value>
        public string ProductId { get; set; }
    }
}
