using ValueAndReferenceTypes;

namespace GarbageCollection
{
    /// <summary>
    /// Program class which acts as the entry point of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Application entry point.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("=======Garbage Collection=======" + Environment.NewLine);

            Console.WriteLine($"Total memory before creating all objects: {GetMemoryInKB()} KB");
            CreateObjects();
            Console.WriteLine($"Total memory after creating all objects: {GetMemoryInKB()} KB");

            GC.Collect();
            Console.WriteLine($"Total memory after triggering garbage collector before finalizers: {GetMemoryInKB()} KB");

            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine($"Total memory after triggering garbage collector: {GetMemoryInKB()} KB");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static long GetMemoryInKB()
        {
            long memory = GC.GetTotalMemory(false);
            return memory / 1024;
        }

        private static void CreateObjects(int objectCount = 10000)
        {
            for (int i = 0; i < objectCount; i++)
            {
                Person person = new Person();
            }
        }
    }
}