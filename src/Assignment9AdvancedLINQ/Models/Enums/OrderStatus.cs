namespace Assignment9AdvancedLINQ.Models.Enums
{
    /// <summary>
    /// Specifies the order status that are available
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Represents the status of order after the order is placed
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Represents the status of order while processing the order
        /// </summary>
        Processing = 2,

        /// <summary>
        /// Represents the status of order after the order is shipped
        /// </summary>
        Shipped = 3,

        /// <summary>
        /// Represents the status of order after delivering the order
        /// </summary>
        Delivered = 4,

        /// <summary>
        /// Represents the status of order after cancelling the order
        /// </summary>
        Cancelled = 5,
    }
}
