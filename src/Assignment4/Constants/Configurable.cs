namespace Assignment4.Constants
{
    /// <summary>
    /// Contains all the configurable.
    /// </summary>
    public class Configurable
    {
        /// <summary>
        /// Represents the maximum number of times the user can retry.
        /// </summary>
        public const int Tries = 3;

        /// <summary>
        /// Represents the format in which the Date is stored.
        /// </summary>
        public const string DateFormat = "dd/MM/yyyy";

        /// <summary>
        /// Represents the minimum character for descriptions.
        /// </summary>
        public const int MinimumCharacter = 3;

        /// <summary>
        /// Represents the maximum character for descriptions.
        /// </summary>
        public const int MaximumCharacter = 30;

        /// <summary>
        /// Represents the minimum amount that can be tracked.
        /// </summary>
        public const int MinimumAmount = 1;

        /// <summary>
        /// Represents the maximum bar length.
        /// </summary>
        public const int MaxBarLength = 20;
    }
}
