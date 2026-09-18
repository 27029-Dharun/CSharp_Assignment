namespace AdvancedFeatures
{
    /// <summary>
    /// Application entry point and composition root.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Controller controller = new Controller();
            //controller.HandleEventsAndDelegate();
            controller.HandleSort();
            //controller.HandleVarAndDynamic();
            Console.ReadKey();
        }
    }
}