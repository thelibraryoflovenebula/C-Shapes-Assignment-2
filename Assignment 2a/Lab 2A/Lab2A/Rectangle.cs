/** STATEMENT OF AUTHORSHIP
 * I, Neil Patrick Olaires, 000964569 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */
using System;

namespace Lab2A
{
    /// <summary>
    /// Rectangle class
    /// subclass of TwoDimensional
    /// </summary>
    public class Rectangle : TwoDimensional
    {

        //ATTRIBUTES
        private double length { get; set; }
        private double width { get; set; }
        private double area { get; }
        private double perimeter { get; }

        //CONSTRUCTOR 

        /// <summary>
        /// Constructor for rectangle class
        /// uses 3 methods to implement area, perimeter, and set dimensions from user input
        /// </summary>
        public Rectangle()
        {
            Type = "Rectangle";
            SetData();
            this.area = CalculateArea();
            this.perimeter = CalculatePerimeter();
        }

        //OVERRIDEN METHODS

        /// <summary>
        /// asks the user to set length and width, with input handling
        /// </summary>
        public override void SetData()
        {
            double lengthValidate = 0;
            double widthValidate = 0;
            bool validate = false;
            while (!validate)
            {
                Console.Write("Enter Rectangle length >>> ");
                string lengthAsk = Console.ReadLine();


                Console.Write("Enter Rectangle width >>> ");
                string widthAsk = Console.ReadLine();


                if (double.TryParse(lengthAsk, out lengthValidate) && double.TryParse(widthAsk, out widthValidate))
                {
                    if (lengthValidate > 0 && widthValidate > 0)
                    {
                        validate = true;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR] Must have positive, non-zero values! >>> ");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR] Must be a number! >>> ");
                }
            }

            this.length = lengthValidate;
            this.width = widthValidate;
        }

        /// <summary>
        /// Calculates area of a rectangle
        /// </summary>
        /// <returns>Calculated area of the given length and width</returns>
        public override double CalculateArea()
        {
            double area = length * width;
            return area;
        }

        /// <summary>
        /// Calculates perimeter of a rectangle
        /// </summary>
        /// <returns>Calculated rectangle perimeter</returns>
        public double CalculatePerimeter()
        {
            double perimeter = 2 * length + 2 * width;
            return perimeter;
        }

        //TO STRING

        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tArea: {this.area:F1}\tPerimeter: {this.perimeter:F1}\tLength: {this.length:F1}\tWidth: {this.width:F1}";
        }

    }
}

/** CHECKLIST
 *  1. SetData()
 *  2. CalculateArea()
 *  3. CalculateVolume()
 *  4. ToString() 
 *              - dimension
 *              - shapeKind
 *              - area (surface area)
 *              - length
 *              - width
 */
