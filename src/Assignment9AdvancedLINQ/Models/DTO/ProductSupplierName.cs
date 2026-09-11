using Assignment9AdvancedLINQ.Models.Enums;

namespace Assignment9AdvancedLINQ.Models.DTO
{
    /// <summary>
    /// Product with the supplier name
    /// </summary>
    public class ProductSupplierName
    {
        /// <summary>
        /// Gets or sets the product id
        /// </summary>
        /// <value>The unique identifier of the product</value>
        public string ProductId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        /// <value>The name of the product</value>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product price
        /// </summary>
        /// <value>The price of the product</value>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the product category
        /// </summary>
        /// <value>The category of the product</value>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the products supplier name
        /// </summary>
        /// <value>The supplier of the product</value>
        public string SupplierName { get; set; } = string.Empty;
    }
}
