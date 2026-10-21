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
    /// Tetrahedron class
    /// subclass of ThreeDimensional
    /// </summary>
    internal class Tetrahedron : ThreeDimensional
    {
        //ATTRIBUTES
        private double sideLength { get; set; }
        private double surfaceArea { get; }
        private double volume { get; }





        //CONSTRUCTOR

        /// <summary>
        /// Constructor for tetrahedron class
        /// uses 3 methods to implement surface area, volume, and set side length from user input
        /// </summary>
        public Tetrahedron()
        {
            Type = "Tetrahedron";
            SetData();
            this.surfaceArea = CalculateArea();
            this.volume = CalculateVolume();
        }

        //METHODS

        /// <summary>
        /// asks the user to set side length, with input handling
        /// </summary>
        public override void SetData()
        {
            double sideLengthValidate = 0;
            bool validate = false;

            while (!validate)
            {
                Console.Write("[EQUALATIRAL] Enter TetraHedron side length >>>");
                string sideLengthAsk = Console.ReadLine();

                if (double.TryParse(sideLengthAsk, out sideLengthValidate))
                {
                    if (sideLengthValidate > 0)
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

            this.sideLength = sideLengthValidate;
        }

        /// <summary>
        /// Calculates surface area of a tetrahedron
        /// </summary>
        /// <returns>Calculated surface area of the given side length</returns>
        public override double CalculateArea()
        {
            double surfaceArea = (Math.Sqrt(3)) * (Math.Pow(this.sideLength, 2));
            return surfaceArea;
        }

        /// <summary>
        /// Calculates volume of a tetrahedron
        /// </summary>
        /// <returns>Calculated tetrahedron volume</returns>
        public override double CalculateVolume()
        {
            double volume = (Math.Pow(this.sideLength, 3)) / (6 * (Math.Sqrt(2)));
            return volume;
        }

        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: Tetrahdrn\tSurface Area: {this.surfaceArea:F1}\tVolume: {this.volume:F1}\tSide Length: {this.sideLength:F1}";
        }
    }
}

/**
 * sa = sqrt(3) a^2
 * v = a^3 / (6 sqrt(2))
 * 
 */
