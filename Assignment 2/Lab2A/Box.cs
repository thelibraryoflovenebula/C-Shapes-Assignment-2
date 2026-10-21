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
    /// Box class
    /// subclass of ThreeDimensional
    /// </summary>
    internal class Box : ThreeDimensional
    {
        //ATTRIBUTES
        private double length { get; set; }
        private double width { get; set; }
        private double height { get; set; }

        private double surfaceArea { get; }
        private double volume { get; }


        //CONSTRUCTOR

        /// <summary>
        /// Constructor for box class
        /// uses 3 methods to implement surface area, volume, and set dimensions from user input
        /// </summary>
        public Box()
        {
            Type = "Box";
            SetData();
            this.surfaceArea = CalculateArea();
            this.volume = CalculateVolume();

        }

        //METHODS

        /// <summary>
        /// asks the user to set length, width and height with input handling
        /// </summary>
        public override void SetData()
        {
            double lengthValidate = 0;
            double widthValidate = 0;
            double heightValidate = 0;

            bool validate = false;
            while (!validate)
            {
                Console.Write("Enter Box length >>> ");
                string lengthAsk = Console.ReadLine();


                Console.Write("Enter Box width >>> ");
                string widthAsk = Console.ReadLine();

                Console.Write("Enter Box height >>> ");
                string heightAsk = Console.ReadLine();


                if (double.TryParse(lengthAsk, out lengthValidate) && double.TryParse(widthAsk, out widthValidate) && double.TryParse(heightAsk, out heightValidate))
                {
                    if (lengthValidate > 0 && widthValidate > 0 && heightValidate > 0)
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
            this.height = heightValidate;
        }

        /// <summary>
        /// Calculates surface area of a box
        /// </summary>
        /// <returns>Calculated surface area of the given dimensions</returns>
        public override double CalculateArea()
        {
            double surfaceArea = 2 * (this.length * this.width + this.length * this.height + this.height * this.width);
            return surfaceArea;
        }

        /// <summary>
        /// Calculates volume of a box
        /// </summary>
        /// <returns>Calculated box volume</returns>
        public override double CalculateVolume()
        {
            double volume = this.length * this.width * this.height;
            return volume;
        }


        /// <summary>
        /// Object format to string to contain variables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tSurface Area: {this.surfaceArea:F1}\tVolume: {this.volume:F1}\tLength: {this.length:F1}\tWidth: {this.width:F1}\t Height: {this.height:F1}";
        }


    }
}

/**
 *  volume = l * w * h
 *  
 *  surface area = 2(lw + lh + hw)
 */
