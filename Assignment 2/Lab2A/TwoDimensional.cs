
using System;

/** STATEMENT OF AUTHORSHIP
 * I, Neil Patrick Olaires, 000964569 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */

namespace Lab2A
{
    /// <summary>
    /// TwoDimensional abstract class
    /// 
    /// overrides calculated volume method to return 0
    /// since 2d shapes have no volume
    /// 
    /// subclass of Shape
    /// parent class to
    ///     -rectangle
    ///     -square
    ///     -circle
    ///     -ellipse
    ///     -triangle
    /// 
    /// </summary>
    public abstract class TwoDimensional : Shape
    {

        private int dimension = 2;

        /// <summary>
        /// Retrieves dimension of the shape
        /// </summary>
        /// <returns>integer value of dimension</returns>
        public int getDimension() { return dimension; }

        /// <summary>
        /// Calculates volume for 2d shapes
        /// 
        /// No need to implement for further 2d shapes (saves time)
        /// 
        /// 
        /// </summary>
        /// <returns>0 for all two dimensional shapes</returns>
        public override double CalculateVolume()
        {
            return 0; //2D shapes have no volume
        }
    }
}
