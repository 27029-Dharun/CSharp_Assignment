using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    internal class ShapeView
    {
        public int DisplayShapeOptions()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Create a Shape");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            return input;
        }

        public Square CreateSquare()
        {
            Console.WriteLine();
        }
    }
}
