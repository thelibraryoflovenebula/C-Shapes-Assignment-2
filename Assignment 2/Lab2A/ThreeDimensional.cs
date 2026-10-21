
using System;

/**  STATEMENT OF AUTHORSHIP
 * I, Neil Patrick Olaires, 000964569 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */

namespace Lab2A
{
    /// <summary>
    /// ThreeDimensional abstract class
    /// 
    /// keeps calculated volume method
    /// 
    /// subclass of Shape
    /// parent class to
    ///     -box
    ///     -cube
    ///     -sphere
    ///     -cylinder
    ///     -tetrahedron
    /// 
    /// </summary>
    public abstract class ThreeDimensional : Shape
    {
        private int dimension = 3;

        /// <summary>
        /// gets the dimension of the shape
        /// </summary>
        /// <returns>integer value of dimension</returns>
        public int getDimension() { return dimension; }
    }
}
