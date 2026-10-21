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
    /// Ellipse class
    /// subclass of TwoDimensional
    /// </summary>
    internal class Ellipse : TwoDimensional
    {
        //ATTRIBUTES
        private double horizontalAxis { get; set; }
        private double verticalAxis { get; set; }

        private double area { get; }
        private double circumfrence { get; }

        //CONSTRUCTOR

        /// <summary>
        /// Constructor for ellipse class
        /// uses 3 methods to implement area, circumfrence, and set axis values from user input
        /// </summary>
        public Ellipse()
        {
            Type = "Ellipse";
            SetData();
            this.area = CalculateArea();
            this.circumfrence = CalculateCircumfrence();
        }



        //OVERRIDDEN METHODS

        /// <summary>
        /// asks the user to set horizontal and vertical axis, with input handling
        /// </summary>
        public override void SetData()
        {
            double horizontalValidate = 0;
            double verticalValidate = 0;
            bool validate = false;
            while (!validate)
            {
                Console.Write("Enter Ellipse Horizontal Axis Value >>> ");
                string horizontalAsk = Console.ReadLine();


                Console.Write("Enter Elliipse Vertical Axis Value >>> ");
                string verticalAsk = Console.ReadLine();


                if (double.TryParse(horizontalAsk, out horizontalValidate) && double.TryParse(verticalAsk, out verticalValidate))
                {
                    if (horizontalValidate > 0 && verticalValidate > 0)
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

            this.horizontalAxis = horizontalValidate;
            this.verticalAxis = verticalValidate;
        }

        /// <summary>
        /// Calculates area of an ellipse
        /// </summary>
        /// <returns>Calculated area of the given axis values</returns>
        public override double CalculateArea()
        {
            double area = PI * this.horizontalAxis * this.verticalAxis;
            return area;
        }

        /// <summary>
        /// Calculates circumfrence of an ellipse using an approximation
        /// </summary>
        /// <returns>Calculated ellipse circumfrence</returns>
        public double CalculateCircumfrence() //improved approximation {https://www.youtube.com/watch?v=r5pl_stL4c0} 
        {
            double topPart = (Math.Pow(this.horizontalAxis, 2)) + (Math.Pow(this.verticalAxis, 2));
            double bottomPart = 2;
            double innerPart = topPart / bottomPart;
            double circumfrence = 2 * PI * Math.Sqrt(innerPart); ;
            return circumfrence;
        }

        /// <summary>
        /// Object format to string to contain vairables
        /// </summary>
        /// <returns>string containing an this class's attributes</returns>
        public override string ToString()
        {
            return $"Dimension: {this.getDimension()}\tType: {this.Type}\tArea: {this.area:F1}\tCirumfrence: {this.circumfrence:F1}\tHorizontal: {this.horizontalAxis:F1}\tVertical{this.verticalAxis:F1}";
        }




    }
}
