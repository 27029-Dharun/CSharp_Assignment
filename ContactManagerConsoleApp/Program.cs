using System.Transactions;

namespace Assignments
{
    /// <summary>
    /// Main Class 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method of the program
        /// </summary>
        public static void Main()
        {
            List<List<string>>? contacts = new List<List<string>>();
            Console.WriteLine("Contact Manager Application");

            string? input;

            do
            {
                Console.WriteLine("Enter the number to Continue with a Operation");
                Console.WriteLine("1. Add the contact");
                Console.WriteLine("2. View the contact");
                Console.WriteLine("3. Edit the contact");
                Console.WriteLine("4. Delete the contact");
                Console.WriteLine("5. Search contact");
                Console.WriteLine("Type [Exit] to Exit");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddContact(contacts);
                        break;

                    case "2":
                        ViewContacts(contacts);
                        break;

                    case "3":
                        EditContact(contacts);
                        break;

                    case "4":
                        DeleteContact(contacts);
                        break;

                    case "5":
                        SearchContacts(contacts);
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input");
                        continue;
                }
            }
            while (input.ToLower() != "exit");

            Console.WriteLine("Exited ...");
            Console.ReadKey();
        }

        private static void AddContact(List<List<string>>? contacts)
        {
            List<string> contact = CreateListContact();
            contacts.Add(contact);
            Console.WriteLine("Contact Added Succesfully !");
            Console.WriteLine();
        }

        private static void ViewContacts(List<List<string>>? contacts)
        {
            int i = 1;

            if (contacts?.Count == 0)
            {
                Console.WriteLine("The Contact list is Empty");
            }

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{i++}. Name : {contact[0]}, Phone : {contact[2]}, Email : {contact[2]}");
            }
            Console.WriteLine();
        }

        private static void DeleteContact(List<List<string>>? contacts)
        {
            Console.WriteLine($"Enter the number of contact to delete");
            ViewContacts(contacts);
            int index = int.Parse(Console.ReadLine()) -1;
            if (index >= 0 && index < contacts?.Count)
            {
                contacts.RemoveAt(index);
                Console.WriteLine($"\nContact list at index {index} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Error: Index out of range.");
            }

            ViewContacts(contacts);
        }

        private static List<string> CreateListContact()
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Phone number: ");
            var phone = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            var email = Console.ReadLine();
            List<string> contact = new List<string> { name, phone, email };
            return contact;
        }

        private static void EditContact(List<List<string>>? contacts)
        {
            Console.WriteLine($"Enter the number of contact to edit");
            ViewContacts(contacts);
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < contacts?.Count)
            {
                List<string> contact = CreateListContact();
                contacts[index] = contact;
                Console.WriteLine($"\nContact list at index {index} edited successfully.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Error: Index out of range.");
            }

            ViewContacts(contacts);
        }

        private static void SearchContacts(List<List<string>> contacts)
        {
            Console.WriteLine("Enter the details to search");
            var str = Console.ReadLine().Trim();
            int flag = 0;
            foreach (var contact in contacts) 
            {
                if (contact[0].Trim() == str || contact[1].Trim() == str || contact[2].Trim() == str)
                {
                    Console.WriteLine("Contact Found !");
                    Console.WriteLine($"Name : {contact[0]} Phone: {contact[1]} Email : {contact[2]}");
                    flag = 1;
                }
            }

            if (flag == 0)
            {
                Console.WriteLine("Contact not Found");
            }
        }
    }
}
