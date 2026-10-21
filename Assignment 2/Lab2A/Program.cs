/** STATEMENT OF AUTHORSHIP
 * I, Neil Patrick Olaires, 000964569 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab2A
{
    /**
     * MAIN METHOD -> view class
     */
    internal class Program
    {
        /// <summary>
        /// Main method
        /// displays menu, creates shapes in modularized format (switch case)
        /// 
        /// INHERITS ALL MADE CLASSES
        /// 
        /// exit -> "x"
        /// 
        /// 
        /// </summary>
        /// <param name="args"> main method</param>
        static void Main(string[] args)
        {

            //Create list of object type Shape
            List<Shape> shapeList = new List<Shape>();

            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine(
                   $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nGEOMETRY CLASS LIST\n\n" +
                    "[2-Dimensions] \t\t[3-Dimensions]\n" +
                    "A: Rectangle\t\tF: Box\n" +
                    "B: Square\t\tG: Tetrahedron\n" +
                    "C: Triangle\t\tH: Sphere\n" +
                    "D: Circle\t\tI: Cylinder\n" +
                    "E: Ellipse\t\tJ: Cube\n\n" +
                   $"0: List all shapes\tX: Exit\n\nCOUNT OF SHAPES: [{Shape.GetCount()}] \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n"
                    );


                Console.Write("Choose an option >>> ");
                string option = Console.ReadLine();

                switch (option.ToUpper())
                {


                    //2 DIMENSIONS
                    //Rectangle 
                    case "A":
                        Shape rectangle = new Rectangle();
                        shapeList.Add(rectangle);
                        break;

                    //Square
                    case "B":
                        Shape square = new Square();
                        shapeList.Add(square);
                        break;

                    //Triangle
                    case "C":
                        Shape triangle = new Triangle();
                        shapeList.Add(triangle);
                        break;

                    //Circle
                    case "D":
                        Shape circle = new Circle();
                        shapeList.Add(circle);
                        break;

                    //Ellipse
                    case "E":
                        Shape ellipse = new Ellipse();
                        shapeList.Add(ellipse);
                        break;




                    //3 DIMENSIONS
                    //Box
                    case "F":
                        Shape box = new Box();
                        shapeList.Add(box);
                        break;

                    //Tetrahedron
                    case "G":
                        Shape tetra = new Tetrahedron();
                        shapeList.Add(tetra);
                        break;

                    //Sphere
                    case "H":
                        Shape sphere = new Sphere();
                        shapeList.Add(sphere);
                        break;

                    //Cylindar
                    case "I":
                        Shape cylinder = new Cylinder();
                        shapeList.Add(cylinder);
                        break;

                    //Cube
                    case "J":
                        Shape cube = new Cube();
                        shapeList.Add(cube);
                        break;


                    //List all shapes from the list shapeList
                    case "0":
                        if (shapeList.Count > 0)
                        {
                            Console.WriteLine($"Total shapes {Shape.GetCount()}");
                            int count = 1;
                            foreach (Shape shape in shapeList)
                            {
                                Console.WriteLine($"[Shape {count}] | {shape}");
                                count++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No shapes in current list! Create a shape!>>> ");
                        }

                        Console.Write("Enter any key to continue >>> ");
                        Console.ReadKey();

                        break;
                    //Exit
                    case "X":
                        running = false;
                        break;

                    //Bad input
                    default:
                        Console.WriteLine(">>> Incorrect Input!");
                        Console.ReadKey();
                        break;
                }
            }

            Console.Write("Have a good day! Press any key to exit >>> ");
            Console.ReadKey();

        }
    }
}
