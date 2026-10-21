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
    /// Cylinder class
    /// subclass of ThreeDimensional
    /// </summary>
    internal class Cylinder : ThreeDimensional
    {
        //ATTRIBUTES 
        private double radius { get; set; }
        private double height { get; set; }

        private double surfaceArea { get; }
        private double volume { get; }

        //CONSTRUCTOR

        /// <summary>
        /// Constructor for cylinder class
        /// uses 3 methods to implement surface area, volume, and set dimensions from user input
        /// </summary>
        public Cylinder()
        {
            Type = "Cylinder";
            SetData();
            this.surfaceArea = CalculateArea();
            this.volume = CalculateVolume();
        }

        //METHODS

        /// <summary>
        /// asks the user to set radius and height, with input handling
        /// </summary>
        public override void SetData()
        {
            double radiusValidate = 0;
            double heightValidate = 0;
            bool validate = false;
            while (!validate)
            {
                Console.Write("Enter Cylinder radius >>> ");
                string radiusAsk = Console.ReadLine();


                Console.Write("Enter Cylinder height >>> ");
                string heightAsk = Console.ReadLine();


                if (double.TryParse(radiusAsk, out radiusValidate) && double.TryParse(heightAsk, out heightValidate))
                {
                    if (radiusValidate > 0 && heightValidate > 0)
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
            this.height = heightValidate;
        }


        /// <summary>
        /// Calculates surface area of a cylinder
        /// </summary>
        /// <returns>Calculated surface area of the given radius and height</returns>
        public override double CalculateArea()
        {
            double surfaceArea = 2 * PI * this.radius * (this.radius + this.height);
            return surfaceArea;
        }

        /// <summary>
        /// Calculates volume of a cylinder
        /// </summary>
        /// <returns>Calculated cylinder volume</returns>
        public override double CalculateVolume()
        {
            double volume = PI * Math.Pow(this.radius, 2) * this.height;
            return volume;
        }

        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tSurface Area: {this.surfaceArea:F1}\tVolume: {this.volume:F1}\tRadius: {this.radius:F1}\tHeight: {this.height:F1}";
        }
    }
}

/**
 * v = pi r^2 h
 * sa = 2 pi r(r + h)
 * 
 */
