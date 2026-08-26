namespace Assignment9AdvancedLINQ.Models.Enums
{
    /// <summary>
    /// Specifies the order status that are available
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Represents the status of order after placing the order
        /// </summary>
        Ordered = 1,

        /// <summary>
        /// Represents the status of order after dispatching the order package
        /// </summary>
        Dispatched = 2,

        /// <summary>
        /// Represents the status of order after delivering the order
        /// </summary>
        Delivered = 3,
    }
}
