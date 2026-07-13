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
        /// <param name="args">Main Method String args</param>
        public static void Main(string[] args)
        {
            List<List<string>>? contacts = new List<List<string>>();
            Console.WriteLine("Contact Manager Application");

            string? input;

            do
            {
                Console.WriteLine("Enter the Key to Continue with a Operation");
                Console.WriteLine("[A]dd the contact");
                Console.WriteLine("[V]iew the contact");
                Console.WriteLine("[E]dit the contact");
                Console.WriteLine("[D]elete the contact");
                Console.WriteLine("Type [Exit] to Exit");

                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "a":
                        AddContact(contacts);
                        Console.WriteLine("Contacts " + contacts);
                        break;

                    case "v":
                        Console.WriteLine("Contacts Added ");
                        ViewContacts(contacts);
                        break;

                    case "s":
                        Console.WriteLine("Search");
                        break;

                    case "e":
                        Console.WriteLine("Edit ");
                        break;

                    case "d":
                        Console.WriteLine("Delete");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input");
                        continue;
                }
            }
            while (input.ToLower() != "exit");

            Console.WriteLine("Enter a Key to Exit");
            Console.ReadKey();
        }
        private static void AddContact(List<List<string>>? contacts)
        {
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Phone number: ");
            var phone = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            var email = Console.ReadLine();
            List<string> contact = new List<string> { name, phone, email };
            contacts.Add(contact);
        }

        private static void ViewContacts(List<List<string>>? contacts)
        {
            int i = 1;
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{i++}. Name : {contact[0]}, Phone{contact[2]}, Email : {contact[2]}");
            }
        }
    }
}
