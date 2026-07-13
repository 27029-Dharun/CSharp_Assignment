namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Contact Manager Application");

            Console.WriteLine("Enter the Key to Continue with a Operation");
            Console.WriteLine("[A]dd the contact");
            Console.WriteLine("[V]iew the contact");
            Console.WriteLine("[E]dit the contact");
            Console.WriteLine("[D]elete the contact");
            Console.WriteLine("Type [Exit] to Exit");

            string input = Console.ReadLine().ToLower();

            do
            {

                switch (input)
                {

                    case "a":
                        Console.WriteLine("Add the Contact ");
                        break;

                    case "v":
                        Console.WriteLine("View the contact ");
                        break;

                    case "e":
                        Console.WriteLine("Edit ");
                        break;

                    case "d":
                        Console.WriteLine("Delete");
                        break;

                    case "x":
                        Console.WriteLine("Program Terminated");
                        break;

                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;

                }

                input = Console.ReadLine().ToLower();

            }
            while (input.ToLower() != "exit");

            Console.WriteLine("Enter a Key to Exit");
            Console.ReadKey();

        }
    }
}
