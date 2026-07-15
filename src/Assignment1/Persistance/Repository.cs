using Assignment1.Model;

namespace Assignment1.Persistance
{
    /// <summary>
    /// this is a repository class
    /// </summary>
    public class Repository
    {
        private static List<ContactInfo> _contactList = new ();

        /// <summary>
        /// This creates contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contact that should bee added to the list</param>
        public void AddContact(ContactInfo contact)
        {
            _contactList.Add(contact);
        }

        /// <summary>
        /// This deletes the contact in the _contact list
        /// </summary>
        /// <param name="id"> this is the contactName that should be updated to the list</param>
        public void DeleteContactById(Guid id)
        {
            ContactInfo contact = GetContactById(id);
            _contactList.Remove(contact);
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="contactName"> this is the contactName that should be updated to the list</param>
        /// <returns>The contact list.</returns>
        public List<ContactInfo> GetContact()
        {
            List<ContactInfo> copy = new List<ContactInfo>();
            foreach (ContactInfo a in _contactList)
            {
                copy.Add(a);
            }

            return copy;
        }

        /// <summary>
        /// Sort the contact by Name
        /// </summary>
        public void SortContactByName()
        {
            _contactList.Sort((a, b) => string.Compare(a.Name, b.Name));
        }

        /// <summary>
        /// Get Contact By Id
        /// </summary>
        /// <param name="id">Id of the Contact</param>
        /// <returns>A contact with id</returns>
        public ContactInfo? GetContactById(Guid id)
        {
            foreach (ContactInfo contact in _contactList)
            {
                if (contact.Id == id)
                {
                    return contact;
                }
            }

            return null;
        }

        /// <summary>
        /// Edit contact with Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="option">Field to change</param>
        /// <param name="newValue">New value to be changed</param>
        public void EditContact(Guid id, int option, string newValue)
        {
            ContactInfo person = GetContactById(id);
            if (person == null)
            {
                return;
            }

            switch (option)
            {
                case 1:
                    person.Name = newValue;
                    break;

                case 2:
                    person.Email = newValue;
                    break;

                case 3:
                    person.Phone = newValue;
                    break;

                case 4:
                    person.Notes = newValue;
                    break;

                default:
                    return ;
            }
        }
    }
}