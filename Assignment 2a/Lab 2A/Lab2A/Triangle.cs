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
    /// Triangle class
    /// subclass of TwoDimensional
    /// </summary>
    internal class Triangle : TwoDimensional
    {
        //ATTRIBUTES
        private double tBase { get; set; }
        private double tHeight { get; set; }
        private double area { get; }

        //CONSTRUCTOR

        /// <summary>
        /// Constructor for triangle class
        /// uses 2 methods to implement area and set dimensions from user input
        /// </summary>
        public Triangle()
        {
            Type = "Triangle";
            SetData();
            this.area = CalculateArea();
        }

        //METHODS

        /// <summary>
        /// asks the user to set base and height, with input handling
        /// </summary>
        public override void SetData()
        {
            double baseValidate = 0;
            double heightValidate = 0;
            bool validate = false;
            while (!validate)
            {
                Console.Write("Enter Triangle base >>> ");
                string baseAsk = Console.ReadLine();


                Console.Write("Enter Triangle height >>> ");
                string heightAsk = Console.ReadLine();


                if (double.TryParse(baseAsk, out baseValidate) && double.TryParse(heightAsk, out heightValidate))
                {
                    if (baseValidate > 0 && heightValidate > 0)
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

            this.tBase = baseValidate;
            this.tHeight = heightValidate;

        }

        /// <summary>
        /// Calculates area of a triangle
        /// </summary>
        /// <returns>Calculated area of the given base and height</returns>
        public override double CalculateArea()
        {
            double area = (1.0 / 2.0) * tBase * tHeight;
            return area;
        }


        /// <summary>
        /// Object format to string to contain variables
        /// </summary>
        /// <returns>string containing triangle attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tArea: {this.area:F1}\tBase: {this.tBase:F1}\tHeight: {this.tHeight:F1}";
        }

    }
}
