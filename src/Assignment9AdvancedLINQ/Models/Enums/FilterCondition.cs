namespace Assignment9AdvancedLINQ.Models.Enums
{
    /// <summary>
    /// Specifies the options available to perform filter
    /// </summary>
    public enum FilterCondition
    {
        /// <summary>
        /// Represents the option to filter the collection greater than or equal operation.
        /// </summary>
        GreaterThanOrEqualTo,

        /// <summary>
        /// Represents the option to filter the collection less than or equal operation.
        /// </summary>
        LessThanOrEqualTo,

        /// <summary>
        /// Represents the option to filter the collection by checking it has the giving characters.
        /// </summary>
        Contains,

        /// <summary>
        /// Represents the option to filter the entries with starting characters.
        /// </summary>
        StartsWith,

        /// <summary>
        /// Represents the option to filter the entries with ending characters.
        /// </summary>
        EndsWith,
    }
}
