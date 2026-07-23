using Assignment2.Models.ShapeHierarchy;

namespace Assignment2.Views
{
    /// <summary>
    /// This class contains view of the Shape
    /// </summary>
    internal class ShapeView
    {
        /// <summary>
        /// This class displays the Operation to do
        /// </summary>
        /// <returns>Int value of the Shape operation</returns>
        public int GetShapeOptions()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Create a Shape");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// This class gets the circle data
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="color">Color</param>
        public void GetCircleData(out double radius, out string color)
        {
            Console.WriteLine("Enter the Radius of the Circle");
            while (!double.TryParse(Console.ReadLine(), out radius))
            {
                Console.WriteLine("Enter a Positive Decimal number");
            }

            Console.WriteLine("Enter the Color of the Circle");
            color = (Console.ReadLine() ?? string.Empty).Trim();
            while (color == string.Empty)
            {
                Console.WriteLine("Color can't be Empty");
                color = (Console.ReadLine() ?? string.Empty).Trim();
            }
        }

        /// <summary>
        /// This class creates a Rectangle
        /// </summary>
        /// <param name="length">Length</param>
        /// <param name="width">Width</param>
        /// <param name="color">Color</param>
        public void GetRectangleData(out double length, out double width, out string color)
        {
            Console.WriteLine("Enter the Length of the Rectangle: ");
            while (!double.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine("Enter a Positive Decimal number");
            }

            Console.WriteLine("Enter the Width of the Rectangle: ");

            while (!double.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Enter a Positive Decimal number");
            }

            Console.WriteLine("Enter the Color of the Rectangle");
            color = (Console.ReadLine() ?? string.Empty).Trim();
            while (color == string.Empty)
            {
                Console.WriteLine("Color can't be Empty");
                color = (Console.ReadLine() ?? string.Empty).Trim();
            }
        }

        /// <summary>
        /// This class prints the shape
        /// </summary>
        /// <param name="shape">Shape object</param>
        public void Print(Shape shape)
        {
            Console.WriteLine(shape.PrintDetails());
        }

        /// <summary>
        /// This print the info that is to be printed
        /// </summary>
        /// <param name="v">String to be printed</param>
        internal void PrintInfo(string v)
        {
            Console.WriteLine(v);
        }
    }
}
