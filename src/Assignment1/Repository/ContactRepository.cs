using System.Data.Common;
using System.Numerics;
using System.Xml.Linq;
using Assignment1.Model;

namespace Assignment1.Persistance
{
    /// <summary>
    /// this is a repository class
    /// </summary>
    public class ContactRepository
    {
        private List<Contact> _contactList = new ();

        /// <summary>
        /// This creates contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contact that should bee added to the list</param>
        public void AddContact(Contact contact)
        {
            this._contactList.Add(contact);
        }

        /// <summary>
        /// This deletes the contact in the _contact list
        /// </summary>
        /// <param name="id"> this is the contactName that should be updated to the list</param>
        /// <returns>Returns status</returns>
        public string DeleteContactById(Guid id)
        {
            Contact? contact = this.GetContactById(id);
            if (contact != null)
            {
                this._contactList.Remove(contact);
                return "Contact Deleted Successfully";
            }

            return "Failed to Delete Contact";
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="contactName"> this is the contactName that should be updated to the list</param>
        /// <returns>The contact list.</returns>
        public List<Contact> GetContacts()
        {
            List<Contact> copy = new List<Contact>();
            foreach (Contact a in this._contactList)
            {
                copy.Add(new Contact { Id = a.Id, Name = a.Name, Phone = a.Phone, Email = a.Email, Notes = a.Notes });
            }

            return copy;
        }

        /// <summary>
        /// Sort the contact by Name
        /// </summary>
        public void SortContactByName()
        {
            this._contactList.Sort((a, b) => string.Compare(a.Name, b.Name));
        }

        /// <summary>
        /// Edit contact with Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="contact">New value to be changed</param>
        /// <returns>string to denote error</returns>
        public string EditContact(Guid id, Contact contact)
        {
            Contact? record = this.GetContactById(id);
            if (record != null)
            {
                record.Name = contact.Name;
                record.Phone = contact.Phone;
                record.Email = contact.Email;
                record.Notes = contact.Notes;
                return "Contact Updated Successfully";
            }

            return "Contact Not Found";
        }

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="id">Id of the Contact</param>
        /// <returns>A contact with id</returns>
        private Contact? GetContactById(Guid id)
        {
            foreach (Contact contact in this._contactList)
            {
                if (contact.Id == id)
                {
                    return contact;
                }
            }

            return null;
        }
    }
}