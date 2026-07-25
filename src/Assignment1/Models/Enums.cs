namespace Assignment1.Models
{
    /// <summary>
    /// This class contains the Enum values
    /// </summary>
    internal static class Enums
    {
        /// <summary>
        /// This enum contains all the contactmanager options
        /// </summary>
        public enum ContactManager
        {
            /// <summary>
            /// This create a Contact
            /// </summary>
            Create = 1,

            /// <summary>
            /// This helps use to view the contacts created
            /// </summary>
            View = 2,

            /// <summary>
            /// This edits the contact
            /// </summary>
            Edit = 3,

            /// <summary>
            /// This deletes the contact
            /// </summary>
            Delete = 4,

            /// <summary>
            /// This search the contact
            /// </summary>
            Search = 5,

            /// <summary>
            /// This sort the contact
            /// </summary>
            Sort = 6,

            /// <summary>
            /// This exits from the application
            /// </summary>
            Exit = 7,
        }
    }
}
