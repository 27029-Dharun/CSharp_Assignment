using Assignment1.Model;

namespace Assignment1.Ui
{
    /// <summary>
    /// Display
    /// </summary>
    internal class DisplayClass
    {
        /// <summary>
        /// Print all the contact list
        /// </summary>
        /// <param name="contacts">Contacts list</param>
        public void PrintContact(List<Contact> contacts)
        {
            if (contacts.Count > 0)
            {
                Console.WriteLine("The Contacts list");
                var i = 1;
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"{i++}. {contact.Name} , {contact.Phone} , {contact.Email} , {contact.Notes} ");
                }
            }
            else
            {
                Console.WriteLine("The Contacts are Empty");
            }
        }
    }
}