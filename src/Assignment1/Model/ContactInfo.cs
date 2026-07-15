using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Model
{
    /// <summary>
    /// Model class
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// Gets or sets the unique id of the Contact.
        /// </summary>
        /// <value>The unique id of the Contact.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Contact.
        /// </summary>
        /// <value>The name of the Contact.</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Email of the Contact.
        /// </summary>
        /// <value>The Email of the Contact.</value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the Contact.
        /// </summary>
        /// <value>The phone number of the Contact.</value>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the Description of the Contact.
        /// </summary>
        /// <value>The Description of the Contact.</value>
        public string? Notes { get; set; }
    }
}