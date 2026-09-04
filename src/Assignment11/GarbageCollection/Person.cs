namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Represents a person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>The name of the person.</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        /// <value>The age of the person.</value>
        public int Age { get; set; }
    }
}
