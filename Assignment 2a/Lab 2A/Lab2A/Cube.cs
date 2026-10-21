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
    /// Cube class
    /// subclass of ThreeDimensional
    /// </summary>
    internal class Cube : ThreeDimensional
    {
        //ATTRIBUTES
        private double length { get; set; }

        private double surfaceArea { get; }
        private double volume { get; }


        //CONSTRUCTOR

        /// <summary>
        /// Constructor for cube class
        /// uses 3 methods to implement surface area, volume, and set length from user input
        /// </summary>
        public Cube()
        {
            Type = "Cube";
            SetData();
            this.surfaceArea = CalculateArea();
            this.volume = CalculateVolume();

        }

        //METHODS

        /// <summary>
        /// asks the user to set length, with input handling
        /// </summary>
        public override void SetData()
        {
            double lengthValidate = 0;
            bool validate = false;

            while (!validate)
            {
                Console.Write("Enter Cube lenghth >>>");
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
        /// Calculates surface area of a cube
        /// </summary>
        /// <returns>Calculated surface area of the given length</returns>
        public override double CalculateArea()
        {
            double surfaceArea = 6 * Math.Pow(this.length, 2);
            return surfaceArea;
        }

        /// <summary>
        /// Calculates volume of a cube
        /// </summary>
        /// <returns>Calculated cube volume</returns>
        public override double CalculateVolume()
        {
            double volume = Math.Pow(this.length, 3);
            return volume;
        }


        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tSurface Area: {this.surfaceArea:F1}\tVolume: {this.volume:F1}\tLength: {this.length:F1}";
        }


    }
}
