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
    /// Sphere class
    /// subclass of ThreeDimensional
    /// </summary>
    internal class Sphere : ThreeDimensional
    {
        //ATTRIBUTES
        private double radius { get; set; }

        private double surfaceArea { get; }
        private double volume { get; }

        //CONSTRUCTOR

        /// <summary>
        /// Constructor for sphere class
        /// uses 3 methods to implement surface area, volume, and set radius from user input
        /// </summary>
        public Sphere()
        {
            Type = "Sphere";
            SetData();
            this.surfaceArea = CalculateArea();
            this.volume = CalculateVolume();
        }

        //METHODS

        /// <summary>
        /// asks the user to set radius, with input handling
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
        /// Calculates surface area of a sphere
        /// </summary>
        /// <returns>Calculated surface area of the given radius</returns>
        public override double CalculateArea()
        {
            double surfaceArea = 4 * PI * Math.Pow(this.radius, 2);
            return surfaceArea;
        }

        /// <summary>
        /// Calculates volume of a sphere (wikipedia forumla)
        /// </summary>
        /// <returns>Calculated sphere volume</returns>
        public override double CalculateVolume()
        {
            double volume = (4.0 / 3.0) * PI * Math.Pow(this.radius, 3);
            return volume;
        }

        /// <summary>
        /// Object format to string to contain variables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tSurface Area: {this.surfaceArea:F1}\tVolume: {this.volume:F1}\tRadius: {this.radius:F1}";
        }


    }
}

/**
 * volume = 4/3 pi r^3
 * 
 * surface area - 4 pi r^2
 * 
 */
