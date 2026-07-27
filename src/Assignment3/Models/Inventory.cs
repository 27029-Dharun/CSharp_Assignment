using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    /// <summary>
    /// Inventory Data
    /// </summary>
    internal class Inventory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="name">Product Name</param>
        /// <param name="price">Product price</param>
        /// <param name="quantity">Product Quantity</param>
        /// Used constructor because all are necessary to create a inventory object
        public Inventory(Guid id, string name, decimal price, int quantity)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.ProductPrice = price;
            this.ProductQuantity = quantity;
        }

        /// <summary>
        /// Gets product Id
        /// </summary>
        /// <value>
        /// Id of the Product
        /// </value>
        public Guid ProductId { get; }

        /// <summary>
        /// Gets or sets product Name
        /// </summary>
        /// <value>
        /// Name of the Product
        /// </value>
        public string? ProductName { get; set; }

        /// <summary>
        /// gets or sets Product Price
        /// </summary>
        /// <value>
        /// Price of the Product
        /// </value>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// gets or sets Product Quantity
        /// </summary>
        /// <value>
        /// Quantity of the Product
        /// </value>
        public int ProductQuantity { get; set; }
    }
}
