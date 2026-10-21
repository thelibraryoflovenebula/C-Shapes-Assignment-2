/** STATEMENT OF AUTHORSHIP
 * I, Neil Patrick Olaires, 000964569 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2A
{
    /// <summary>
    /// Square class
    /// subclass of TwoDimensional
    /// </summary>
    internal class Square : TwoDimensional
    {

        //ATTRIBUTES

        private double length { get; set; }
        private double area { get; }
        private double perimeter { get; }

        //CONSTRUCTOR 

        /// <summary>
        /// Constructor for square class
        /// uses 3 methods to implement area, perimeter, and set length from user input
        /// </summary>
        public Square()
        {
            Type = "Square";
            SetData();
            this.area = CalculateArea();
            this.perimeter = CalculatePerimeter();
        }

        //OVERRIDEN METHODS

        /// <summary>
        /// asks the user to set length, with input handling
        /// </summary>
        public override void SetData()
        {
            double lengthValidate = 0;
            bool validate = false;
            while (!validate)
            {
                Console.Write("Enter Square length >>> ");
                string lengthAsk = Console.ReadLine();

                if (double.TryParse(lengthAsk, out lengthValidate))
                {
                    if (lengthValidate > 0)
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

        }

        /// <summary>
        /// Calculates area of a square
        /// </summary>
        /// <returns>Calculated area of the given length</returns>
        public override double CalculateArea()
        {
            double area = Math.Pow(this.length, 2);
            return area;
        }

        /// <summary>
        /// Calculates perimeter of a square
        /// </summary>
        /// <returns>Calculated square perimeter</returns>
        public double CalculatePerimeter()
        {
            double perimeter = 4 * this.length;
            return perimeter;
        }

        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tArea: {this.area:F1}\tPerimeter: {this.perimeter:F1}\tLength: {this.length:F1}";
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
