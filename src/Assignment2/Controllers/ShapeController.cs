using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.ShapeHierarchy;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This enum represents all the Task as enum
    /// </summary>
    internal enum ChooseShape
    {
        /// <summary>
        /// Shape
        /// </summary>
        Circle = 1,

        /// <summary>
        /// Employee
        /// </summary>
        Rectangle = 2,
    }

    /// <summary>
    /// THis is the Shape Controller
    /// </summary>
    internal class ShapeController
    {
        private ShapeView _shapeview = new ();
        private ShapeService _shapeservice = new ();

        /// <summary>
        /// This method is the entery point for Shape
        /// </summary>
        public void Run()
        {
            int input = this._shapeview.GetShapeOptions();
            switch (input)
            {
                case (int)ChooseShape.Circle:
                    this._shapeview.CreateCircle(out double radius, out string circleColor);
                    Circle circle = this._shapeservice.CreateCircle(radius, circleColor);
                    this._shapeview.Print(circle);

                    break;

                case (int)ChooseShape.Rectangle:
                    this._shapeview.GetRectangleData(out double length, out double width, out string rectangleColor);
                    Rectangle rectangle = this._shapeservice.CreateRectangle(length, width, rectangleColor);
                    this._shapeview.Print(rectangle);

                    break;
            }
        }
    }
}