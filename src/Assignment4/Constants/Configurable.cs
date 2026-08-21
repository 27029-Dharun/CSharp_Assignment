namespace Assignment4.Constants
{
    /// <summary>
    /// Contains all configurable constants used across the application.
    /// This class cannot be instantiated.
    /// </summary>
    public class Configurable
    {
        /// <summary>
        /// Represents the maximum number of times the user can retry.
        /// </summary>
        public const int Tries = 3;

        /// <summary>
        /// Represents the standard date format used for storing and displaying dates..
        /// </summary>
        public const string DateFormat = "dd/MM/yyyy";

        /// <summary>
        /// Represents the minimum character for descriptions and category.
        /// </summary>
        public const int MinimumCharacter = 3;

        /// <summary>
        /// Represents the maximum character for descriptions.
        /// </summary>
        public const int MaximumCharacter = 30;

        /// <summary>
        /// Represents the maximum character for category.
        /// </summary>
        public const int MaximumCategoryCharacter = 15;

        /// <summary>
        /// Represents the minimum amount that can be tracked.
        /// </summary>
        public const int MinimumAmount = 1;

        /// <summary>
        /// Represents the maximum length of the bar chart
        /// </summary>
        public const int MaxBarLength = 40;
    }
}
