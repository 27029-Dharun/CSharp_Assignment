using Assignment9AdvancedLINQ.Models.Enums;

namespace Assignment9AdvancedLINQ.Models
{
    /// <summary>
    /// Represents an order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="orderId">Unique identifier for an order</param>
        /// <param name="orderDate">Date on which the order is placed</param>
        /// <param name="orderStatus">Status of the order</param>
        public Order(string orderId, DateTime orderDate, OrderStatus orderStatus)
        {
            this.OrderId = orderId;
            this.OrderDate = orderDate;
            this.OrderStatus = orderStatus;
        }

        /// <summary>
        /// Gets or sets the order id
        /// </summary>
        /// <value>The unique identifier for each order</value>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the Order date from the user.
        /// </summary>
        /// <value>Date on which the order is placed.</value>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the Order.
        /// </summary>
        /// <value>Status of the order.</value>
        public OrderStatus OrderStatus { get; set; }
    }
}
