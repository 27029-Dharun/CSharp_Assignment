namespace Assignment4.Helper
{
    /// <summary>
    /// Enum helpers that are used to print the values in the enum
    /// </summary>
    internal class EnumHelper
    {
        /// <summary>
        /// Gets a Enum value a returns it as a List
        /// </summary>
        /// <typeparam name="T">Type variable accepts enums</typeparam>
        /// <returns>List of enum variables</returns>
        public static IEnumerable<T> GetAllEnumValues<T>()
        where T : Enum // Enforce T is a enum
        {
            Array valuesArray = Enum.GetValues(typeof(T));

            return (T[])valuesArray;
        }
    }
}
