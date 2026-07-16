using System.Data.Common;
using System.Numerics;
using System.Xml.Linq;
using Assignment1.Model;

namespace Assignment1.Persistance
{
    /// <summary>
    /// this is a repository class
    /// </summary>
    public class Repository
    {
        private List<ContactInfo> _contactList = new ();

        /// <summary>
        /// This creates contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contact that should bee added to the list</param>
        public void AddContact(ContactInfo contact)
        {
            this._contactList.Add(contact);
        }

        /// <summary>
        /// This deletes the contact in the _contact list
        /// </summary>
        /// <param name="id"> this is the contactName that should be updated to the list</param>
        public void DeleteContactById(Guid id)
        {
            ContactInfo? contact = this.GetContactById(id);
            if (contact != null)
            {
                this._contactList.Remove(contact);
            }
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="contactName"> this is the contactName that should be updated to the list</param>
        /// <returns>The contact list.</returns>
        public List<ContactInfo> GetContacts()
        {
            List<ContactInfo> copy = new List<ContactInfo>();
            foreach (ContactInfo a in this._contactList)
            {
                copy.Add(new ContactInfo { Id = a.Id, Name = a.Name, Phone = a.Phone, Email = a.Email, Notes = a.Notes });
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
        public void EditContact(Guid id, ContactInfo contact)
        {
            ContactInfo? record = this.GetContactById(id);
            record.Name = contact.Name;
            record.Phone = contact.Phone;
            record.Email = contact.Email;
            record.Notes = contact.Notes;
        }

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="id">Id of the Contact</param>
        /// <returns>A contact with id</returns>
        private ContactInfo? GetContactById(Guid id)
        {
            foreach (ContactInfo contact in this._contactList)
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