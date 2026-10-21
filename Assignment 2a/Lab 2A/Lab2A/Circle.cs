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
    /// Circle class
    /// subclass of TwoDimensional 
    /// </summary>
    internal class Circle : TwoDimensional
    {
        //ATTRIBUTES
        private double radius { get; set; }
        private double area { get; }
        private double circumfrence { get; }


        //CONSTRUCTOR

        /// <summary>
        /// Constructor for circle class
        /// uses 3 methods to implement area, circumfrence, and set radius from user input
        /// </summary>
        public Circle()
        {
            Type = "Circle";
            SetData();
            this.area = CalculateArea();
            this.circumfrence = CalculateCircumfrence();
        }

        //METHODS

        /// <summary>
        /// asks the user to set data, with input handling
        /// </summary>
        public override void SetData()
        {
            double radiusValidate = 0;
            bool validate = false;

            while (!validate)
            {
                Console.Write("Enter Circle radius >>>");
                string radiusAsk = Console.ReadLine();

                if (double.TryParse(radiusAsk, out radiusValidate))
                {
                    if (radiusValidate > 0)
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

            this.radius = radiusValidate;

        }

        /// <summary>
        /// Calculates area of a circle
        /// </summary>
        /// <returns>Calculated area of the given radius</returns>
        public override double CalculateArea()
        {
            double area = PI * (Math.Pow(this.radius, 2)); //pi r squared 
            return area;
        }

        /// <summary>
        /// Calculates circumfrence of a circle
        /// </summary>
        /// <returns>Calculated circle circumfrence</returns>
        public double CalculateCircumfrence()
        {
            double circumfrence = 2 * PI * this.radius;
            return circumfrence;
        }

        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tArea: {this.area:F1}\tCirumfrence: {this.circumfrence:F1}\tRadius: {this.radius:F1}";
        }

    }
}
