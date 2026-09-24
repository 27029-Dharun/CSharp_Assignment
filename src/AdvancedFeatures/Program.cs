namespace AdvancedFeatures
{
    /// <summary>
    /// Application entry point and composition root.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Controller controller = new Controller();
            controller.Run();
        }
    }
}